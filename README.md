# Surveys
Proyecto en C# desarrollado con .NET Core, que utiliza Entity Framework (EF Core) como ORM para la gestión de datos y Swagger para la documentación interactiva de la API.

## 🚀 Tecnologías utilizadas
- .NET Core X.X
- Entity Framework Core
- Swagger / Swashbuckle
- PostgreSQL

## ⚙️ Configuración del entorno
1. Clona el repositorio:

```bash
   git clone https://github.com/LauraVargas22/PublicForms.git
   cd PublicForms
```

2. Configura la cadena de conexión en [appsettings.Development.json](./ApiProject/appsettings.Development.json)

```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=publicForms;Username=postgres;Password=Lau05032015"
  }
```

3. Aplica las migraciones
```bash
 dotnet ef database update
```

4. Ejecuta el proyecto
```bash
 cd ApiProject
 dotnet run
```

## 📘 Swagger
[Implementación de Swagger](https://www.canva.com/design/DAGpk0N4xfY/kNOXKS5IvqZpiqz9UcE_rA/edit?utm_content=DAGpk0N4xfY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)
Una vez iniciado el proyecto, puedes acceder a la documentación interactiva de Swagger en:

```bash
https://localhost:{puerto}/swagger
```

## ✍️ Colaboradores
- [Isabela Galvis](https://github.com/Isa94d-lab)
- [Valentina Caballero](https://github.com/hdvalen/hdvalen)
- [Laura Vargas](https://github.com/LauraVargas22)
- [Andrés Araque](https://github.com/amdresw/amdresw)

