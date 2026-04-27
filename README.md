# 🛒 MiAppWeb - API REST con ASP.NET + Frontend HTML

Proyecto simple de una API REST desarrollada con ASP.NET Core (.NET 8) y un frontend en HTML, CSS y JavaScript puro.

Permite:

* 📦 Ver productos
* ➕ Agregar productos
* 💾 Persistir datos en un archivo JSON

---

## 🚀 Tecnologías usadas

* ASP.NET Core (.NET 8)
* C#
* HTML5
* CSS3
* JavaScript (Fetch API)
* System.Text.Json

---

## 📁 Estructura del proyecto

```
MiAppWeb/
├── Program.cs
├── productos.json
├── wwwroot/
│   └── index.html
├── appsettings.json
├── appsettings.Development.json
└── MiAppWeb.csproj
```

---

## ⚙️ Cómo ejecutar el proyecto

### 1. Clonar el repositorio

```bash
git clone https://github.com/TU_USUARIO/TU_REPO.git
cd MiAppWeb
```

### 2. Ejecutar la API

```bash
dotnet run
```

### 3. Abrir en el navegador

```
http://localhost:5200
```

---

## 🔌 Endpoints de la API

### GET `/api/productos`

Obtiene la lista de productos

Ejemplo de respuesta:

```json
[
  {
    "id": 1,
    "nombre": "Teclado",
    "precio": 10000
  }
]
```

---

### POST `/api/productos`

Agrega un nuevo producto

Ejemplo de request:

```json
{
  "nombre": "Mouse",
  "precio": 5000
}
```

---

## 💾 Persistencia de datos

Los productos se almacenan en:

```
productos.json
```

* Se crea automáticamente si no existe
* Se actualiza en cada POST
* Permite mantener los datos tras reiniciar la aplicación

---

## 🌐 Frontend

El frontend está en:

```
wwwroot/index.html
```

Funciones principales:

* Cargar productos automáticamente (`fetch`)
* Renderizar lista en pantalla
* Enviar nuevos productos a la API

---

## ⚠️ Consideraciones

* No hay base de datos (usa JSON como almacenamiento)
* No incluye validaciones avanzadas
* No incluye autenticación

---

## 🚧 Posibles mejoras

* 🗄️ Integrar base de datos (SQLite / PostgreSQL)
* ✅ Validaciones en backend
* 🔐 Autenticación
* ⚛️ Migrar frontend a React o framework moderno

---

## 👨‍💻 Autor

Desarrollado por Lautaro Hillkirk

GitHub: https://github.com/HillkirkLautaro
