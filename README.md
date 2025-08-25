# ZuvoPetApiAzure - API para Gestión de Adopciones de Mascotas

## 🚀 Descripción

API web desarrollada con .NET para la gestión integral de adopciones de mascotas, refugios, usuarios y veterinarios. Permite la administración de datos, autenticación, almacenamiento de imágenes y consulta de historias de éxito.

## 🛠️ Tecnologías Utilizadas

- **Framework:** .NET 9
- **Lenguajes:** C#, JSON
- **ORM:** Entity Framework Core
- **Autenticación:** OAuth
- **Almacenamiento:** Azure Blob Storage
- **CI/CD:** GitHub Actions

## ✨ Características

- ✅ **Gestión de adoptantes, refugios y veterinarios**
- ✅ **Autenticación segura con OAuth**
- ✅ **Almacenamiento de imágenes en Azure Blob Storage**
- ✅ **Consulta y registro de historias de éxito**
- ✅ **API RESTful con endpoints claros y documentados**
- ✅ **Configuración flexible por entorno (Development/Production)**
- ✅ **Integración con servicios externos**
- ✅ **Estructura modular y escalable**

## 📱 Funcionalidades Principales

### 🏠 Gestión de Adopciones
Administración de usuarios, mascotas, refugios y veterinarios, con endpoints para registro, consulta y actualización de datos.

### 🖼️ Almacenamiento de Imágenes
Carga y gestión de imágenes de mascotas y usuarios mediante Azure Blob Storage, accesibles desde la API.

### 🔒 Autenticación y Seguridad
Implementación de OAuth para autenticación segura y gestión de tokens de usuario.

### 📖 Historias de Éxito
Registro y consulta de historias de adopción exitosas, con imágenes y detalles relevantes.

## 🏗️ Estructura del Proyecto

```
ZuvoPetApiAzure/
├── Controllers/
│   ├── AdoptanteController.cs
│   ├── AuthController.cs
│   └── RefugioController.cs
├── Data/
│   └── ZuvoPetContext.cs
├── Helpers/
│   ├── HelperActionServicesOAuth.cs
│   ├── HelperAvatarDinamico.cs
│   ├── HelperCriptography.cs
│   ├── HelperPathProvider.cs
│   └── HelperUsuarioToken.cs
├── Repositories/
│   ├── IRepositoryZuvoPet.cs
│   └── RepositoryZuvoPet.cs
├── Services/
│   └── ServiceStorageBlobs.cs
├── wwwroot/
│   └── images/
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── ZuvoPetApiAzure.csproj
└── README.md
```

## 🌐 Endpoints Principales

La API proporciona endpoints para la gestión de adoptantes, refugios, veterinarios y almacenamiento de imágenes:

- **GET /api/adoptantes** - Listar adoptantes
- **POST /api/adoptantes** - Registrar adoptante
- **GET /api/refugios** - Listar refugios
- **POST /api/refugios** - Registrar refugio
- **GET /api/veterinarios** - Listar veterinarios
- **POST /api/veterinarios** - Registrar veterinario
- **POST /api/images/upload** - Subir imagen

## 📈 Rendimiento y Optimización

- 📱 API optimizada para alta concurrencia
- ⚡ Configuración flexible por entorno
- 🔄 Integración con Azure para almacenamiento eficiente
- 🎨 Manejo elegante de errores y estados

## 🔄 Actualizaciones Recientes

**v1.0.0** (2025) - Lanzamiento inicial
- Gestión completa de adoptantes, refugios y veterinarios
- Almacenamiento de imágenes en Azure Blob Storage
- Autenticación OAuth implementada
- Estructura modular y escalable
- Endpoints RESTful documentados
- Manejo de historias de éxito

---

## 📄 Licencia

Este proyecto está disponible para visualización y evaluación profesional. Ver el archivo [LICENSE](LICENSE) para más detalles sobre términos de uso y restricciones.
