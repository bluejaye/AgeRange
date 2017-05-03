## Age Range Demo
###### By Jay (zjaybbs@Gmail.com)

#### Project Structure
The main architecture for the demo is created with simplified DDD, CQRS and Onion. The project is consisted of four parts: Domain (domain model, services with unit test and contracts), Infrastructure (Data Repository), Application (Web API and DTO) and Web (angular 2 application).

**Domain** is the core part. All the business rules are included inside. Because it is so important so I will add Unit Test for it to test 

**Infrastructure** mainly provider the data Repository. It implemented the contracts (interfaces) from Domain. This part can be replaced with a different implementation (eg. change sqlite DB to SQL Server). 

**Application** include Web API and DTO (Data Transfer Object) Project. Web API provides all the APIs. DTO contains DTO model and Adapter used by Web API project

**Web** is an independent project constructed by Angular 2 and Typescript.


- Framework and Libraries Used:
- Dot Net Core for Web API
- Microsoft dependency injection
- Sqlight SDK
- Entity Framework 6
- Unit of Work Pattern
- xUnit for Unit Test
- Moq 4 for Mokcing data
- Angular CLI for run and test front end
- TypeScript 


Please let me know if there's further suggestion you can think of.


#### Applications required to run
1. Visual Studio 2017
2. NPM
3. Angular CLI


#### Configure project to run
1. Open AgeRanger.sln by VS 2017
2. Run API
3. Double check the API port is 56418, otherwise need to change Angular 2 Endpoint API
4. Run **npm install** in the **web** folder to install node_modules. 
5. run **ng server** to start angular 2 web site
6. open http://localhost:4200/ in a browser


Please let me know if you met any problem to start the projects