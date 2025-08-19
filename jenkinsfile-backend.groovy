pipeline {
    agent any

    environment {
        REPO_URL = "https://github.com/GenaroAlvarez/mdeis-m8-devops-backend"
        BACKEND_DIR = "mdeis-m8-devops-backend"
        PROJECT_NAME = "SolidProducts"
        PUBLISH_DIR = "${BACKEND_DIR}\\publish"
        NGINX_PATH = "C:\\tools\\nginx"
        API_PORT = "5000"
        FRONTEND_PORT = "8080"
        SERVICE_NAME = "SolidProductsBackendService"
    }

    stages {
        stage('Checkout Github project') {
            steps {
                git url: "${REPO_URL}", branch: "master"
            }
        }

        stage('Restore dependencies') {
            steps {
                dir(BACKEND_DIR) {
                    bat "dotnet restore"
                }
            }
        }

        stage('Stop API background service') {
            steps {
                script {
                    bat """
                    sc query ${SERVICE_NAME} >nul 2>&1
                    if %ERRORLEVEL% EQU 0 (
                        echo Stopping ${SERVICE_NAME}...
                        sc stop ${SERVICE_NAME} >nul 2>&1 || echo Service wasn't running
                        sc delete ${SERVICE_NAME} >nul 2>&1 || echo Service didn't exist
                    ) else (
                        echo ${SERVICE_NAME} doesn't exists
                    )
                    exit /b 0
                    """

                    // Stops Nginx
                    // bat """
                    // taskkill /IM nginx.exe /F || echo Nginx wasn't running
                    // """
                }
            }
        }

        stage('Publish project as a self contained service') {
            steps {
                dir(BACKEND_DIR) {
                    bat """
                    dotnet publish ${PROJECT_NAME} -c Release --runtime win-x64 --self-contained -o publish
                    """
                }
            }
        }

        stage('Set configuration') {
            steps {
                writeFile file: "${PUBLISH_DIR}\\appsettings.json", text: """
                {
                  "Urls": "http://localhost:${API_PORT}",
                  "AllowedOrigins": "http://localhost:${FRONTEND_PORT}",
                  "ConnectionStrings": {
                    "DefaultConnection": "Server=localhost;Database=products;User Id=sa;Password=Password123!;TrustServerCertificate=True;Encrypt=False;"
                  }
                }
                """
            }
        }

        stage('Run API as a background service') {
            steps {
                bat """
                sc create ${SERVICE_NAME} binPath="${env.WORKSPACE}\\${PUBLISH_DIR}\\${PROJECT_NAME}.exe" start=auto
                sc start ${SERVICE_NAME}
                """
            }
        }

        // stage('Iniciar Nginx') {
        //     steps {
        //         bat """
        //         cd ${NGINX_PATH}
        //         start nginx.exe
        //         """
        //     }
        // }
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
