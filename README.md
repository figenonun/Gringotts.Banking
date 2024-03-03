This project has developed based on DDD. You will find basic crud operations about user, account, transaction. As you see project separated as Application and Domain layer.
Target framework is .Net 8. The project is code first approach.
Entity Framework Core has used as ORM tool. You need to Migrate your entities with Add-Migration and Update-Database commands.
FluentValidation has used for Error-Proof System.
Result class has created as Response Modeling.
Basic Authentication has added for Authentication.
Logging has used for logs.
Sql Database has used as storage and run on Docker.
Swagger has added for API Documentation.

You can use sql Server menagament studio on your local computer. Or you can run below code to run sql on docker.
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest

