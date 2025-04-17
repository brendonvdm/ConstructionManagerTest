# Project README

## Getting Started

### Using Docker Compose
To start both frontend and backend services together:
```bash
docker-compose up --build
```

### Running Services Individually

### *Note:* Due to hardware failure on my personal laptop, I had to continue working on this project on my work laptop. Unfortunately, my work laptop has security policies that prevent running executables. As a result, I was unable to test the backend outside of Docker.


**Backend:**
update appSettings.json and set "UseInMemoryDatabase": true,
or point to your own MS Sql Server

```bash
cd backend
dotnet restore
dotnet run
```

**Frontend:**
```bash
cd frontend
npm install
npm start
```


## Project Overview
This is a full-stack application with a modern frontend and a cleanly architected backend. The frontend provides a responsive user interface while the backend handles business logic and data persistence.

## Backend Architecture
**Key Technologies:**
- .NET 9 (framework)
- Entity Framework Core (database ORM)
- ASP.NET Core (web framework)
- JWT (authentication)
- MediatR (CQRS)
- AutoMapper (object mapping)
- Serilog (logging)
- Docker (containerization)

**Clean Architecture Implementation:**
The backend follows clean architecture principles with:
1. Domain layer (entities, business logic)
2. Application layer (use cases, DTOs)
3. Infrastructure layer (persistence, external services)
4. Presentation layer (API controllers)

**Project Structure:**
- Solution organized by feature
- Dependency injection for loose coupling
- Repository pattern for data access
- MediatR for CQRS implementation

## Frontend Implementation
**Key Packages & Tools:**
- Chakra UI (UI library)
- React (UI library)
- Redux (state management)
- Vite (module bundler)
- ESLint (code linting)
- TypeScript (type checking)
- Docker (containerization)
- Tailwind CSS (CSS framework)

**Structure:**
The frontend uses a component-based architecture with:
- Container components (state management)
- Presentational components (UI rendering)
- Services (API communication)
- Utils (helper functions)

## Testing Note
Due to time constraints, tests were not implemented. Future work should include:
- Unit tests for both frontend and backend
- Integration tests
- End-to-end tests
- Performance tests
- Security tests
- Code coverage analysis
- Continuous integration/continuous deployment (CI/CD)


## Acknowledgments
- [Chakra UI](https://chakra-ui.com/)
- [React](https://reactjs.org/)
- [Vite](https://vitejs.dev/)
- [TypeScript](https://www.typescriptlang.org/)
- [Docker](https://www.docker.com/)
- [Tailwind CSS](https://tailwindcss.com/)
- [Serilog](https://serilog.net/)
- [MediatR](https://github.com/serilog/serilog-extensions)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [JWT](https://jwt.io/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [ASP Dotnet Core Clean Architecture](https://marketplace.visualstudio.com/items?itemName=SamanAzadi1996.ASPDotnetCoreCleanArchitecture)