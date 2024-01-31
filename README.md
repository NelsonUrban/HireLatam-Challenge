# HireLatam Challenge

## Description
This application is an example that uses Angular 16 on the frontend and .NET Core 6 on the backend. It utilizes a multi-layered architecture on the backend, implementing the Mediator, CQRS, and Repository patterns. Communication between the frontend and backend is done via RESTful APIs.

## Technologies Used
- **Frontend**: Angular 16
- **Backend**: .NET Core 6
- **Patterns**: Mediator, CQRS, Repository
- **Database**: SQL Server
- **Additional Tools**: Swagger

## Prerequisites
- Node.js
- Angular CLI
- .NET Core SDK

## Setup
1. **Frontend**: Navigate to the `frontend/` directory and run `npm install` to install dependencies.
2. **Backend**: Navigate to the `backend/` directory and run `dotnet restore` to restore NuGet packages.

## Execution
1. **Frontend**: From the `frontend/` directory, run `ng serve` to start the Angular development server. Navigate to `http://localhost:4200/`.
2. **Backend**: From the `backend/` directory, run `dotnet run` to start the .NET Core development server. The backend will be available at `http://localhost:5000/`.

## Usage
Before running the application, ensure the following steps:

1. **Run Migrations**: Before starting the backend server, run Entity Framework Core migrations to apply any pending database schema changes. Navigate to the `backend/` directory and execute the following command:
    ```
    dotnet ef database update
    ```
   This will ensure that the database schema is up to date.

2. **Specify SQL Server Connection String**: Update the `appsettings.development.json` file in the `backend/` directory with the connection string for your SQL Server. Replace the placeholder values with your SQL Server details:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;User=YOUR_USERNAME;Password=YOUR_PASSWORD;"
      }
    }
    ```
   Replace `YOUR_SERVER_NAME`, `YOUR_DATABASE_NAME`, `YOUR_USERNAME`, and `YOUR_PASSWORD` with your SQL Server connection details.

3. **Start the Application**: Once migrations are applied and the connection string is specified, you can start the frontend and backend servers as described in the "Execution" section.


## Project Structure
- **frontend/**: Contains the source code of the Angular frontend.
- **backend/**: Contains the source code of the .NET Core backend.
- **docs/**: Additional documentation, if applicable.

## License
- Specify the license under which your application is distributed.

## Contact
- [Email]: urbannelson@hotmail.com
- [LinkedIn]: [Nelson Urban](https://www.linkedin.com/in/nelson-nehemias-urban-marten-410159b8/)

## Credits
- All resources and contributions by [NelsonUrban](https://github.com/NelsonUrban).