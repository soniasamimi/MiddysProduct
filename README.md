# Middys Products 

A full-stack web app to manage a list of products built with **ASP.NET Core Web API (.NET 8)** and **React**.  
The solution supports full CRUD functionality and is designed with layered architecture principles to ensure scalability and maintainability.

---

##   Project Structure & Design

###  Layered Architecture
- **API Project**: Entry point with controllers and Swagger setup
- **Services Project**: Business logic, service interfaces, and unit tests
- **Data Project**: EF Core DbContext, entity models, repositories

###  Dependency Injection
- Repositories and services are injected where needed
- Makes testing easier and improves maintainability

###  DTOs & AutoMapper
- Used DTOs to keep the API clean and not expose internal models
- AutoMapper handles mapping between entities and DTOs

###  Frontend (React)
- Built with React functional components and hooks
- Axios for API calls
- Bootstrap 5 for styling
- Basic routing in place for future expansion

---

##  Assumptions

- The backend will initially use an **in-memory database** for simplicity; a real database can be swapped later.
- No authentication or user roles are implemented at this stage.
- The frontend will run locally at `http://localhost:3000` and access the backend via CORS at `https://localhost:7174`.

---

##  Getting Started

###  Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js (18+)](https://nodejs.org/)
- [npm](https://www.npmjs.com/)

---

##  Run the Backend (API)

1. Navigate to the solution folder root:
   ```bash
   dotnet build   
2. Run the API project:
   ```bash
   dotnet run   
3. Swagger UI:
   ```bash
   https://localhost:7174/swagger/index.html
   
 ## Run the Frontend (React)
 
 1. Navigate to the frontend folder:
    ```bash
    cd frontend/middys-products-web
    
2. Install dependencies:
   ```bash
    npm install
   
3. Start the React development server:
   ```bash
    npm start
   
4. Access the app:
   ```bash
    http://localhost:3000

##   Running Tests (API)
  Unit tests are written using [xUnit](https://xunit.net/) and [Moq](https://github.com/moq/moq4) for mocking dependencies.

  To run all tests in the test project:

  ```bash
   dotnet test MiddysProducts.Services.Tests