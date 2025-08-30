pipeline {
    agent any

    parameters {
        string(name: 'GIT_URL', defaultValue: 'https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git', description: 'URL del repositorio Git')

        string(name: 'GIT_BRANCH_PROD', defaultValue: 'master', description: 'Rama para producción')
        string(name: 'GIT_BRANCH_DEVELOPMENT', defaultValue: 'dev', description: 'Rama para desarrollo')
        string(name: 'GIT_BRANCH_TEST', defaultValue: 'qa', description: 'Rama para test')

        string(name: 'FRONTEND_DIR', defaultValue: 'mdeis-m8-devops-frontend', description: 'Carpeta del frontend dentro del repo')

        string(name: 'BACKEND_URL_PROD', defaultValue: 'http://localhost:5050/api/v1', description: 'URL del backend para producción')
        string(name: 'BACKEND_URL_DEVELOPMENT', defaultValue: 'http://localhost:5051/api/v1', description: 'URL del backend para desarrollo')
        string(name: 'BACKEND_URL_TEST', defaultValue: 'http://localhost:5052/api/v1', description: 'URL del backend para test')

        string(name: 'NGINX_HTML_PATH_TEST', defaultValue: 'C:\\Program Files\\nginx\\html\\grupo5-frontend-test\\', description: 'Ruta de destino para test')
        string(name: 'NGINX_HTML_PATH_DEVELOPMENT', defaultValue: 'C:\\Program Files\\nginx\\html\\grupo5-frontend-development\\', description: 'Ruta de destino para desarrollo')
        string(name: 'NGINX_HTML_PATH_PROD', defaultValue: 'C:\\Program Files\\nginx\\html\\grupo5-frontend-production\\', description: 'Ruta de destino para producción')

        booleanParam(name: 'DEPLOY_TEST', defaultValue: false, description: '¿Desplegar en ambiente de test?')
        booleanParam(name: 'DEPLOY_DEVELOPMENT', defaultValue: false, description: '¿Desplegar en ambiente de desarrollo?')
        booleanParam(name: 'DEPLOY_PROD', defaultValue: false, description: '¿Desplegar en ambiente de producción?')
    }

    stages {

        stage('Build for Environments') {
            parallel {
                stage('Build for Test') {
                    when { expression { return params.DEPLOY_TEST } }
                    steps {
                        buildForEnvironment('test', params.BACKEND_URL_TEST, params.GIT_BRANCH_TEST)
                    }
                }
                stage('Build for Development') {
                    when { expression { return params.DEPLOY_DEVELOPMENT } }
                    steps {
                        buildForEnvironment('development', params.BACKEND_URL_DEVELOPMENT, params.GIT_BRANCH_DEVELOPMENT)
                    }
                }
                stage('Build for Production') {
                    when { expression { return params.DEPLOY_PROD } }
                    steps {
                        buildForEnvironment('production', params.BACKEND_URL_PROD, params.GIT_BRANCH_PROD)
                    }
                }
            }
        }

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

        stage('Deploy to Environments') {
            parallel {
                stage('Deploy to Test') {
                    when { expression { return params.DEPLOY_TEST } }
                    steps {
                        deployToEnvironment('test', params.NGINX_HTML_PATH_TEST)
                    }
                }
                stage('Deploy to Development') {
                    when { expression { return params.DEPLOY_DEVELOPMENT } }
                    steps {
                        deployToEnvironment('development', params.NGINX_HTML_PATH_DEVELOPMENT)
                    }
                }
                stage('Deploy to Production') {
                    when { expression { return params.DEPLOY_PROD } }
                    steps {
                        deployToEnvironment('production', params.NGINX_HTML_PATH_PROD)
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
            echo 'Proceso de despliegue del frontend completado.'
        }
        failure {
            echo 'El despliegue falló, revisa los logs para más detalles.'
        }
    }
}

def buildForEnvironment(String environment, String backendUrl, String branch) {
    dir("${environment}-src") {
        git(url: params.GIT_URL, branch: branch)

        dir(params.FRONTEND_DIR) {
            bat 'npm install'

            def envConfig = """
            VITE_BACKEND_URL=${backendUrl}
            """
            writeFile file: ".env.${environment}", text: envConfig

            bat "npx tsc -b && npx vite build --mode ${environment} --outDir dist-${environment}"
        }
    }
}

def deployToEnvironment(String environment, String nginxPath) {
    powershell(returnStdout: true, script: "Remove-Item -Path \"${nginxPath}*\" -Include *.* -Force")
    echo "Clean-Up done for ${environment}."

    String command = "Copy-Item -Path \"${WORKSPACE}\\${environment}-src\\${params.FRONTEND_DIR}\\dist-${environment}\\*\" -Destination \"${nginxPath}\" -Recurse -Force"
    powershell(returnStdout: true, script: command)
    echo "Files copied successfully to ${environment}."
}
