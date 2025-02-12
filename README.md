# Aplicación CRUD de Usuarios con MongoDB

Esta es una aplicación simple en C# para gestionar usuarios con operaciones CRUD utilizando MongoDB. La aplicación utiliza WinForms para la interfaz gráfica, permitiendo crear, leer, actualizar y eliminar usuarios de manera intuitiva.

## Características

- **Crear Usuario**: Agregar un nuevo usuario con un ID único, nombre de usuario y correo electrónico.
- **Leer Usuarios**: Listar todos los usuarios en la base de datos.
- **Actualizar Usuario**: Actualizar el nombre de usuario y/o correo electrónico de un usuario existente.
- **Eliminar Usuario**: Eliminar un usuario de la base de datos y reciclar su ID.

## Requisitos

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework)
- [MongoDB](https://www.mongodb.com/try/download/community)
- [Visual Studio Community](https://visualstudio.microsoft.com/vs/community/)

## Configuración

1. **Clonar el repositorio**:
    ```sh
    git clone https://github.com/tu-usuario/nuevo-repo.git
    cd nuevo-repo
    ```

2. **Abrir el proyecto en Visual Studio Community**:
    - Abre `MongoDBUserCRUD.sln` en Visual Studio.

3. **Configurar MongoDB**:
    - Asegúrate de que MongoDB esté en funcionamiento en tu máquina local.
    - Actualiza la cadena de conexión de MongoDB en el archivo `UserService.cs` si es necesario:
      ```csharp
      var client = new MongoClient("mongodb://localhost:27017");
      ```

4. **Ejecutar la aplicación**:
    - Presiona `F5` o haz clic en `Start` en Visual Studio para ejecutar la aplicación.

## Uso

- **Crear Usuario**: Ingresa el nombre de usuario y el correo electrónico, luego haz clic en "Crear Usuario".
- **Listar Usuarios**: Haz clic en "Listar Usuarios" para ver todos los usuarios.
- **Actualizar Usuario**: Ingresa el ID del usuario, el nuevo nombre de usuario y/o el nuevo correo electrónico, luego haz clic en "Actualizar Usuario".
- **Eliminar Usuario**: Ingresa el ID del usuario a eliminar, luego haz clic en "Eliminar Usuario".
