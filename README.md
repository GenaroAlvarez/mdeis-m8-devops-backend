# POS Backend – SolidProducts

## Descripción
Este proyecto es el backend de un sistema **POS (Point of Sale)** desarrollado en **.NET 8**, diseñado para gestionar productos, ventas y operaciones relacionadas.  
Incluye una API RESTful que puede ser consumida por un frontend POS o integrarse con sistemas externos.

---

## Tecnologías utilizadas
- **.NET 8** (ASP.NET Core Web API)
- **C#**
- **SQL Server 2022**
- **nginx** (como proxy inverso)

---

## Prerrequisitos
Antes de instalar y ejecutar el proyecto, asegúrate de contar con:
- [SDK de .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server 2022 Developer o Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [nginx para Windows](https://nginx.org/en/download.html)
<!-- - Puerto **80** (o el configurado en nginx) libre -->
<!-- - Puerto **1433** (SQL Server) libre -->
<!-- - Al menos **2 GB** de memoria disponible -->

---

## Instalación

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/GenaroAlvarez/mdeis-m8-devops-backend.git
   cd mdeis-m8-devops-backend
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

---

## Despliegue

### 1. Publicar el proyecto
Genera la versión lista para producción:
```bash
dotnet publish -c Release -o ./publish
```
Esto creará los archivos en la carpeta `publish`.

### 2. Configurar nginx
Edita el archivo `nginx.conf` para agregar el proxy inverso:
```nginx
server {
    listen 80;

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

### 3. Ejecutar la API
Inicia la API publicada desde la carpeta `publish`:
```bash
dotnet SolidProducts.dll --urls "http://localhost:5000"
```

### 4. Iniciar nginx
Ejecuta `nginx.exe` desde su carpeta de instalación:
```bash
start nginx
```

### 5. Ejecuta el script de datos
Ejecuta el script `inserts.sql` para llenar datos iniciales.


Ahora tu API estará accesible en:
```
http://localhost
```

Para validar funcionamiento, ingresa a la siguiente URL:
```
http://localhost/api/v1/products
```