# Net-Core-API-Technical-Challenge
Technical Challenge for a Backend Engineer role

## Prerequisite
1. Visual Studio 2022
2. ASP.NET and web development component

## How to run
1. Clone/Download project
2. Open solution file in VS2022 (.sln file)
3. Run with IIS Express

## How to use
1. Click on "Authorize" or any unlock icon
2. Enter basic authorization (Username: admin | Password: myawesomepassword)
3. Click "Authorize" at the bottom
4. Close authorization popup
5. Call any API using the OpenAPI UI

## Questions
1. Approximately 3 hours for everything
2. Adding a user table in database and implement JWT authentication for each user instead of a hardcoded username and password basic authentication
3. The separation of models, controllers, and data access (DAL). Codes are separated into their respective folder/files to serve a particular purpose instead of having everything together. This provides a cleaner look for the project and makes it easier for collaboration and modification.
4. Basic authentication. Normally authentication is done at the start of the project. It has been a while since I have looked at authentication codes so adding a simple username and password authentication took me a while.
5. The 3 main libraries used are Entity Framework (EF) Core, OpenAPI (Swagger), and Newtonsoft Json. EF Core is an Object Relational Mapper (ORM) that helps to quickly interface with the database to perform transactions without needing to write raw SQL queries, as well as setting up or updating schemas through migrations. OpenAPI (Swagger) helps to provide a UI to quickly test our APIs. Newtonsoft Json is used to help us serialise and deserialise complex data types that otherwise, would not be able to be stored into our database easily.
6. I think the challenge aims to reveal if the participant has sufficient knowledge to work on a backend system and perform the basics such as API development, database interfacing, and some security.
7. I think the challenge is practical in terms of what will be done in a real working environment and I think it is good enough as is.
8. None
