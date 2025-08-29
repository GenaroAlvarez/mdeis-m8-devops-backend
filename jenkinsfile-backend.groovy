pipeline {
    agent any

    parameters {
        string(name: 'GIT_URL', defaultValue: 'https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git', description: 'URL del repositorio Git')

        string(name: 'GIT_BRANCH_PROD', defaultValue: 'master', description: 'Rama para producción')
        string(name: 'GIT_BRANCH_DEVELOPMENT', defaultValue: 'dev', description: 'Rama para desarrollo')
        string(name: 'GIT_BRANCH_TEST', defaultValue: 'qa', description: 'Rama para test')

        string(name: 'BACKEND_DIR', defaultValue: 'mdeis-m8-devops-backend', description: 'Carpeta del backend dentro del repo')
        string(name: 'PROJECT_NAME', defaultValue: 'SolidProducts', description: 'Nombre del proyecto .NET')

        string(name: 'API_PORT_PROD', defaultValue: '5000', description: 'Puerto interno de la API en producción')
        string(name: 'API_PORT_DEVELOPMENT', defaultValue: '5001', description: 'Puerto interno de la API en desarrollo')
        string(name: 'API_PORT_TEST', defaultValue: '5002', description: 'Puerto interno de la API en test')

        string(name: 'NGINX_PORT_PROD', defaultValue: '5050', description: 'Puerto expuesto en producción')
        string(name: 'NGINX_PORT_DEVELOPMENT', defaultValue: '5051', description: 'Puerto expuesto en desarrollo')
        string(name: 'NGINX_PORT_TEST', defaultValue: '5052', description: 'Puerto expuesto en test')

        string(name: 'FRONTEND_PORT_PROD', defaultValue: '8080', description: 'Puerto del frontend production')
        string(name: 'FRONTEND_PORT_DEVELOPMENT', defaultValue: '8081', description: 'Puerto del frontend development')
        string(name: 'FRONTEND_PORT_TEST', defaultValue: '8082', description: 'Puerto del frontend test')

        string(name: 'DB_NAME_PROD', defaultValue: 'products_prod', description: 'Base de datos para producción')
        string(name: 'DB_NAME_DEVELOPMENT', defaultValue: 'products_dev', description: 'Base de datos para desarrollo')
        string(name: 'DB_NAME_TEST', defaultValue: 'products_test', description: 'Base de datos para test')

        booleanParam(name: 'DEPLOY_TEST', defaultValue: true, description: '¿Desplegar en ambiente de test?')
        booleanParam(name: 'DEPLOY_DEVELOPMENT', defaultValue: false, description: '¿Desplegar en ambiente de desarrollo?')
        booleanParam(name: 'DEPLOY_PROD', defaultValue: false, description: '¿Desplegar en ambiente de producción?')
    }

    stages {
        stage('Stop nginx process') {
            steps {
                powershell '''
                    if (Get-Service -Name "nginx" -ErrorAction SilentlyContinue) {
                        if ((Get-Service -Name "nginx").Status -eq "Running") {
                            net stop nginx
                            Write-Host "nginx detenido"
                        } else {
                            Write-Host "nginx ya estaba detenido"
                        }
                    } else {
                        Write-Host "nginx no está registrado como servicio"
                    }
                '''
            }
        }

        stage('Cleanup Previous Services') {
            steps {
                script {
                    if (params.DEPLOY_TEST) {
                        stopServiceIfExists('test')
                    }
                    if (params.DEPLOY_DEVELOPMENT) {
                        stopServiceIfExists('development')
                    }
                    if (params.DEPLOY_PROD) {
                        stopServiceIfExists('production')
                    }
                }
            }
        }

        stage('Build for Environments') {
            parallel {
                stage('Build for Test') {
                    when { expression { return params.DEPLOY_TEST } }
                    steps {
                        buildForEnvironment('test', params.GIT_BRANCH_TEST, params.API_PORT_TEST, params.FRONTEND_PORT_TEST, params.DB_NAME_TEST)
                    }
                }
                stage('Build for Development') {
                    when { expression { return params.DEPLOY_DEVELOPMENT } }
                    steps {
                        buildForEnvironment('development', params.GIT_BRANCH_DEVELOPMENT, params.API_PORT_DEVELOPMENT, params.FRONTEND_PORT_DEVELOPMENT, params.DB_NAME_DEVELOPMENT)
                    }
                }
                stage('Build for Production') {
                    when { expression { return params.DEPLOY_PROD } }
                    steps {
                        buildForEnvironment('production', params.GIT_BRANCH_PROD, params.API_PORT_PROD, params.FRONTEND_PORT_PROD, params.DB_NAME_PROD)
                    }
                }
            }
        }

        stage('Deploy Services') {
            parallel {
                stage('Deploy to Test') {
                    when { expression { return params.DEPLOY_TEST } }
                    steps {
                        deployToEnvironment('test', params.API_PORT_TEST, params.NGINX_PORT_TEST)
                    }
                }
                stage('Deploy to Development') {
                    when { expression { return params.DEPLOY_DEVELOPMENT } }
                    steps {
                        deployToEnvironment('development', params.API_PORT_DEVELOPMENT, params.NGINX_PORT_DEVELOPMENT)
                    }
                }
                stage('Deploy to Production') {
                    when { expression { return params.DEPLOY_PROD } }
                    steps {
                        deployToEnvironment('production', params.API_PORT_PROD, params.NGINX_PORT_PROD)
                    }
                }
            }
        }

        stage('Start nginx process') {
            steps {
                powershell(returnStdout:true, script:'net start nginx')
                echo 'The nginx process has been started.'
            }
        }
    }

    post {
        always {
            echo 'Proceso de despliegue del backend completado.'
        }
        failure {
            echo 'El despliegue falló, revisa los logs para más detalles.'
        }
    }
}

def buildForEnvironment(String environment, String branch, String apiPort, String frontendPort, String dbName) {
    dir("${environment}-src") {
        git(url: params.GIT_URL, branch: branch)

        dir(params.BACKEND_DIR) {
            bat "dotnet restore"

            bat """
            dotnet publish ${params.PROJECT_NAME} -c Release --runtime win-x64 --self-contained -o publish
            """

            def config = """
            {
              "Urls": "http://localhost:${apiPort}",
              "AllowedOrigins": "http://localhost:${frontendPort}",
              "ConnectionStrings": {
                "DefaultConnection": "Server=localhost;Database=${dbName};User Id=sa;Password=Password123!;TrustServerCertificate=True;Encrypt=False;"
              },
              "Env": "${environment}"
            }
            """
            writeFile file: "publish/appsettings.json", text: config
        }
    }
}

def deployToEnvironment(String environment, String apiPort, String nginxPort) {
    def serviceName = "SolidProductsBackendService-${environment}"

    powershell """
        if (Get-Service -Name '${serviceName}' -ErrorAction SilentlyContinue) {
            sc stop ${serviceName}
            sc delete ${serviceName}
        }
    """

    bat """
    sc create ${serviceName} binPath="${WORKSPACE}\\${environment}-src\\${params.BACKEND_DIR}\\publish\\${params.PROJECT_NAME}.exe" start=auto
    sc start ${serviceName}
    """

    echo "Backend desplegado en ${environment} -> API interna ${apiPort}, expuesto por Nginx en ${nginxPort}"
}

def stopServiceIfExists(String environment) {
    def serviceName = "SolidProductsBackendService-${environment}"
    powershell """
        if (Get-Service -Name '${serviceName}' -ErrorAction SilentlyContinue) {
            Stop-Service -Name '${serviceName}' -Force
            Write-Host "Servicio ${serviceName} detenido para limpieza"
        }
    """
}
