# Ordering Sample Project
This project is a sample Domain Driven Design microservice for Ordering

Figure below shows how a layered design is implemented in the eShopOnContainers application:
![alt text](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/ddd-oriented-microservice/domain-driven-design-microservice.png)

And figure below shows dependencies between layers:
![alt text](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/ddd-oriented-microservice/ddd-service-layer-dependencies.png
)

## Installation

Use dotnet restore to restore all package dependencies.

```bash
dotnet restore
```
Then change the current directory to project directory and use dotnet run to run the project
```bash
dotnet run
```
The database for this project will automatically be migrated.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.