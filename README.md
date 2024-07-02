# Prime Numbers API with .NET

# The main architectural patterns and styles that guide this solution are

- Port and Adapter Architecture
- CQRS (Command Query Responsibility Segregation)

# Technical specifications:

- Entity Framework Core 6
- Generic Repository (very useful with aggregate management)
- Shadow Properties on entities: Properties that are added to domain entities without "poisoning" the entity's own definition in that layer.
- Automatic Domain Services injection using "[DomainService]" annotation.
- MediaTR : register command handlers and queries automatically (via reflection does scan of the assembly)
- Global Exception Handler
- Logs : Console
- Swagger

### Project structure:

Solution for VisualStudio(.sln) composed of the following folders :

- Algorithm: Console application with the solution of the algorithm
- Api : Api Rest, entry point of the application
- Application : Domain Services Orchestration Layer; Ports, Commands, Queries, Handlers
- Infrastructure : Adapters
- Domain : Entities, Value Objects, Ports, Domain Services, Aggregates
- app : React application to consume api

# Screenshots

## 1. Console application running the prime number algorithm
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/section%201.2%20Primer%20Numer.png" />

## 2. Web Api running
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/Swagger.png" />

## 3. Displaying the message in the queue with Service Bus Explorer
<img src="https://github.com/klmeir/NetMessaging/blob/main/docs/3.png" />

## 4. Execution of unit tests to the domain.
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/Tests.png" />

## 5. Query of data registered in sql server
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/Sql.png" />

## 6. Generated database script
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/Script.png" />

## 7. Client in react running
<img src="https://github.com/klmeir/PrimeNumber/blob/master/docs/GUI.png" />

## Build & Run

# Visual Studio 2022

To run the project open the solution in visual studio, check the database connection string and run the script to create tables and test data
