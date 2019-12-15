# Mini-Carsales MVP

A vehicle management system that for MVP will only cater for cars, but in the future will manage other vehicle types like boats, bikes, caravans etc.

## Versioning
* .NET Core 3.1
* node v10.16.3
* npm 6.9.0

## Up & Running
* Clone the prject
* Use Visual Studio 2019 and open `MiniCarsales.sln` and run using `MiniCarsales.Web` project
* Or open termial and `cd MiniCarsales.Web/` then run `dotnet run`
* The Api is accessible at [https://localhost:5001/api/cars](https://localhost:5001/api/cars) or [http://localhost:5000/api/cars](http://localhost:5000/api/cars)
* If need to restore the database, delete the db file at `MiniCarsales.Web/App_Data/MiniCarsales.db`, then open
"Package Manager Console" and run `Update-Database` using the `MiniCarsales.Models` project.

## Run Tests
### Frontend Tests
* `cd MiniCarsales.Web/ClientApp` then run `npm run test`

### Backend Test
* Run tests using Visual Studio test explorer

## Api Documentation
* Api documentation is accessible at [https://localhost:5001/swagger](https://localhost:5001/swagger) or [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Libraries
### Frontend
1. **react**
2. **react-router**
3. **react-redux**
4. **reactstrap**
5. **react-thunk**
6. **bootstrap**
7. **enzyme**

### Backend
1. **Entity Framework Core** for data access
2. **AutoMapper** for mapping data models to Dtos
3. **Moq** for mocking
4. **Entity Framework Core In Memory Database** for integration testing
5. **Newtonsoft.Json** for deserializing response in integration testing
6. **Swagger** for API documentation
7. **XUnit** for unit testing