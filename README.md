# POS System - SolidProducts (FullStack)
## 🌟 Descripción
Sistema completo **Point of Sale (POS)** con:
- **Backend:** API REST en .NET 8 para gestión de productos/ventas
- **Frontend:** Aplicación React/Vite con TypeScript
- **Infraestructura:** NGINX como proxy inverso y servidor web

## 📊 Diagrama del Sistema
<div align="center">
  <img src="assets/diagram.png" alt="Diagrama" width="200px" height="auto">
</div>

## 👥 Página de Clientes
<div align="center">
  <img src="assets/clients-page.png" alt="Clients" width="800px" height="auto">
</div>

## 💰 Página de Ventas
<div align="center">
  <img src="assets/sales-page.png" alt="Sales" width="800px" height="auto">
</div>

## 🚀 Tecnologías utilizadas
### Backend
- **.NET 8** (ASP.NET Core Web API)
- **C#**
- **SQL Server 2022**
- **nginx** (como proxy inverso)

### Frontend
- **Vite**: Bundler rápido para desarrollo moderno.
- **TypeScript**: Tipado estático para JavaScript.
- **ESLint**: Estándares de calidad y consistencia de código.
- **Node.js & npm**: Gestión de dependencias.

## 📦 Prerrequisitos
### Backend
Antes de instalar y ejecutar el proyecto, asegúrate de contar con:
- [SDK de .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server 2022 Developer o Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [nginx para Windows](https://nginx.org/en/download.html)
<!-- - Puerto **80** (o el configurado en nginx) libre -->
<!-- - Puerto **1433** (SQL Server) libre -->
<!-- - Al menos **2 GB** de memoria disponible -->

### Frontend
Antes de iniciar, asegúrate de tener instalado:

- [Node.js](https://nodejs.org/) — Versión recomendada: **22.x**
- npm — Incluido con la instalación de Node.js

## ⚙️ Instalación
### Backend
1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git
   cd mdeis-m8-devops-backend/mdeis-m8-devops-backend
   ```

2. **Restaurar dependencias**
   ```bash
   dotnet restore
   ```

3. **Configurar cadena de conexión**
   Edita el archivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=products;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True;Encrypt=False;"
     }
   }
   ```

### Frontend
1. **Clonar el repositorio**
  ```bash
  git clone https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git
  cd mdeis-m8-devops-backend/mdeis-m8-devops-frontend
  ```

2. **Instalar dependencias**
  ```bash
  npm install
  ```
3. **Ejecución en entorno local**
  Para desarrollo:
  ```bash
  npm run dev
  ```

## 🚀 Despliegue
### Backend
#### 1. Restaurar dependencias del proyecto
```bash
dotnet restore
```

#### 2. Publicar el proyecto
Genera la versión lista para producción:
```bash
dotnet publish SolidProducts -c Release --runtime win-x64 --self-contained -o publish
```
Esto creará los archivos en la carpeta `publish`.

#### 3. Configura las variables de entorno
Según el ambiente, crear el archivo `appsettings.json` dentro de la carpeta `./release` configurando las siguientes variables:
- `BACKEND_PORT`: Puerto interno de despliegue del backend
- `FRONTEND_PORT`: Puerto de despliegue del frontend
- `DATABASE`: Nombre de base de datos

```json
{
  "Urls": "http://localhost:BACKEND_PORT",
  "AllowedOrigins": "http://localhost:FRONTEND_PORT",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DATABASE;User Id=sa;Password=Password123!;TrustServerCertificate=True;Encrypt=False;"
  }
}
```

#### 4. Crea y ejecuta servicio
Crear el servicio de Windows para ejecutar el backend en background, configurando las siguientes variables:
- `ENV`: Ambiente de despligue (DEV, TEST, PROD)
- `PUBLISH_PATH`: Dirección donde se publicó el proyecto en el paso 2

```bash
sc create SolidProductsBackendService-ENV binPath="PUBLISH_PATH\\SolidProducts.exe" start=auto
sc start SolidProductsBackendService-ENV
```

#### 5. Configurar nginx
Edita el archivo `nginx.conf` para agregar el proxy inverso:
```nginx
# Backend - Development
server {
    listen 5051;

    location / {
        proxy_pass         http://localhost:5001;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

# Backend - Test
server {
    listen 5052;

    location / {
        proxy_pass         http://localhost:5002;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}

# Backend - Production
server {
    listen 5050;

    location / {
        proxy_pass         http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header   Upgrade $http_upgrade;
        proxy_set_header   Connection keep-alive;
        proxy_set_header   Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header   X-Forwarded-Proto $scheme;
    }
}
```

#### 6. Iniciar nginx
Ejecuta `nginx.exe` desde su carpeta de instalación:
```bash
start nginx
```

#### 7. Accede a los servicios

La API estará accesible en:
```nginx
# Development
http://localhost:5001

# Test
http://localhost:5002

# Production
http://localhost:5000
```

Para validar funcionamiento, ingresa a la siguiente URL:
```nginx
# Development
http://localhost:5001/status

# Test
http://localhost:5002/status

# Production
http://localhost:5000/status
```

#### 8. Ejecuta el script de datos (solo la primera vez)
Ejecuta el script `inserts.sql` para llenar datos iniciales.

### Frontend
#### 1. Crear directorios para cada ambiente
Navega hacia el directorio `../nginx/html` y crea tres directorios, uno para cada ambiente:

```bash
# Development
grupo5-frontend-development/

# Test
grupo5-frontend-test/

# Production
grupo5-frontend-production/
```

#### 2. Despliegue por Ambiente
Generación de archivos estáticos para los distintos ambientes:

```bash
# Development
npm run build:development

# Test
npm run build:test

# Production
npm run build
```

Luego, mueve los archivos generados en `../mdeis-m8-devops-frontend/dist-<ambiente>/` al directorio de NGINX del ambiente destino:
```bash
# Development
../mdeis-m8-devops-frontend/dist-development/ -> ../nginx/html/grupo5-frontend-development/

# Test
../mdeis-m8-devops-frontend/dist-test/ -> ../nginx/html/grupo5-frontend-test/

# Production
../mdeis-m8-devops-frontend/dist-production/ -> ../nginx/html/grupo5-frontend-production/
```

Estructura Final de Directorios
```bash
../nginx/html/
├── grupo5-frontend-development/    # Ambiente de desarrollo
├── grupo5-frontend-test/           # Ambiente de test
└── grupo5-frontend-production/     # Ambiente de producción
```

#### 3. Configurar NGINX
Ingresa al archivo `../nginx/conf/nginx.conf` y agrega este bloque de configuración para cada ambiente:
```nginx
    # Frontend - sDevelopment
    server {
        listen       8081;
        server_name  localhost;

        root   "<PATH_NGINX>/html/grupo5-frontend-development";
        index  index.html;

        location / {
            try_files $uri $uri/ /index.html;
        }
    }

    # Frontend - sTest
    server {
        listen       8082;
        server_name  localhost;

        root   "<PATH_NGINX>/html/grupo5-frontend-test";
        index  index.html;

        location / {
            try_files $uri $uri/ /index.html;
        }
    }

    # Frontend - sProduction
    server {
        listen       8080;
        server_name  localhost;

        root   "<PATH_NGINX>/html/grupo5-frontend-production";
        index  index.html;

        location / {
            try_files $uri $uri/ /index.html;
        }
    }
```

#### 4: Reiniciar NGNIX
Ejecuta los comandos en el CMD (como administrador):
1. Recargar la configuración
```
nginx -t          # Verifica que la sintaxis sea correcta
nginx -s reload   # Recarga la configuración
```
2. Detener Nginx (si está en ejecución)
```
nginx -s stop
```

3. Iniciar Nginx (nueva instancia)
```
start nginx
```
o usando el comando como servicio:
```
net stop nginx
net start nginx
```

#### 5: Accede a la aplicación
La aplicación estará disponible en:
```nginx
# Development
http://localhost:8081

# Test
http://localhost:8082

# Production
http://localhost:8080

```