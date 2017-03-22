## Creating a .NET Core 1.1 MVC Web Application from scratch
    https://www.youtube.com/watch?v=y_J8geOgO-Y&list=PL7u53lOSm0rxzkpOsswWZS4SzhODcex-F

## Points
    * ASP.NET Core 1.1, ViewModel
    * EF, Migration, Models
    * Identity
    * MS SQL
    * Docker
    * Image Upload

How to run
----------------------
1. Start the mssql docker
    $ docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Sql@1433' -p 1433:1433 -d microsoft/mssql-server-linux

2. Recover databas
    $dotnet ef database update

3. Start app
    $ dotnet run

4. Login
    test@gmail.com/
    Test1234