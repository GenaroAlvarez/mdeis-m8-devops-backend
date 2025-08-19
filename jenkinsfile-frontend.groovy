pipeline {
    agent any

    parameters {
        string(name: 'GIT_URL', defaultValue: 'https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git', description: 'URL del repositorio Git')
        string(name: 'GIT_BRANCH', defaultValue: 'master', description: 'Rama a clonar')
        string(name: 'FRONTEND_DIR', defaultValue: 'mdeis-m8-devops-frontend', description: 'Carpeta del frontend dentro del repo')
        string(name: 'NGINX_HTML_PATH', defaultValue: 'C:\\Program Files\\nginx\\html\\grupo5-frontend\\', description: 'Ruta de destino de archivos en nginx')
    }

    stages {
        stage('Stop nginx process') {
            steps {
                powershell(returnStdout:true, script:'net stop nginx')
                echo 'The nginx process has been stopped.'
            }
        }

        stage('Checkout Github Project') {
            steps {
                git(url: params.GIT_URL, branch: params.GIT_BRANCH)
            }
        }

        stage('Install Dependencies') {
            steps {
                dir(params.FRONTEND_DIR) {
                    bat 'npm install'
                }
            }
        }

        stage('Build with Vite') {
            steps {
                dir(params.FRONTEND_DIR) {
                    bat 'npx tsc -b && npx vite build'
                }
            }
        }

        stage('Clean-Up Old Files') {
            steps {
                powershell(returnStdout:true, script:"Remove-Item -Path \"${params.NGINX_HTML_PATH}*\" -Include *.* -Force")
                echo 'Clean-Up done.'
            }
        }

        stage('Copy Files') {
            steps {
                script {
                    String command = "Copy-Item -Path \"${WORKSPACE}\\${params.FRONTEND_DIR}\\dist\\*\" -Destination \"${params.NGINX_HTML_PATH}\" -Recurse -Force"
                    echo command
                    powershell(returnStdout:true, script: command)
                    echo 'Files copied successfully.'
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
