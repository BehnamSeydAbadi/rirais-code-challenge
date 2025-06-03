# RiRa Code Challenge

A .NET 8 web application that demonstrates modern web API development with both REST and gRPC endpoints for user management operations.

## 🎯 Goal

This solution showcases a clean architecture approach for building scalable web APIs with comprehensive user management functionality. It serves as a code challenge implementation demonstrating best practices in modern .NET development.

## 🚀 Technologies Used

### Core Framework
- **.NET 8** - Latest LTS version of .NET
- **ASP.NET Core** - Web framework for building APIs

### API Technologies
- **REST API** - Traditional HTTP endpoints with OpenAPI documentation
- **gRPC** - High-performance RPC framework for efficient communication
- **Protocol Buffers** - Serialization format for gRPC services

### Documentation & Development
- **Swagger/OpenAPI** - API documentation and testing interface
- **Swashbuckle.AspNetCore** - Swagger integration for ASP.NET Core

### Data & Persistence
- **Entity Framework Core** - Object-relational mapping (ORM)
- **EF Core Design** - Design-time tools for migrations and scaffolding

### Architecture & Patterns
- **Clean Architecture** - Separation of concerns with domain-driven design
- **Domain-Driven Design (DDD)** - Value objects and domain modeling

### DevOps & Deployment
- **Docker** - Containerization with Linux target OS
- **Docker Compose** - Multi-container application orchestration

## 📁 Project Structure

```
rirais-code-challenge/
├── rirais.WebApi/          # Web API layer with REST and gRPC endpoints
├── rirais.Infrastructure/   # Data access and external services
├── rirais.Domain/          # Domain models and business logic
└── README.md
```

## 🏗️ Architecture Highlights

- **Value Objects**: Implemented for domain concepts like `FullName` with built-in validation
- **Application Services**: Separated concerns for user operations (Get, Update, etc.)
- **Dual API Support**: Both REST and gRPC endpoints for flexibility
- **Containerized**: Ready for deployment with Docker support

## 🔧 Key Features

- User management with CRUD operations
- Input validation and domain constraints
- RESTful API endpoints with proper HTTP status codes
- gRPC services for high-performance scenarios
- Comprehensive API documentation via Swagger
- Docker containerization for easy deployment

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- Docker (optional)

### Running the Application

#### Using .NET CLI
```bash
cd rirais.WebApi
dotnet run
```

#### Using Docker
```bash
docker build -t rirais-webapi .
docker run -p 8080:80 rirais-webapi
```

### API Documentation
Once running, access the Swagger UI at: `http://localhost:5066/swagger` or `https://localhost:5067/swagger`.
In order to use gRPC services, you need to call only `https://localhost:5067`

## 📝 API Endpoints

### REST API
- `POST /api/users` - Register new user
- `GET /api/users` - Get all users
- `GET /api/users/{id}` - Get user by Id
- `PUT /api/users/{id}` - Update user details
- `DELETE /api/users/{id}` - Unregister the user

### gRPC Services
- User service with Protocol Buffer definitions
- High-performance binary communication
- Strongly-typed contracts

---

*This project demonstrates modern .NET development practices and serves as a comprehensive example of building scalable web APIs with clean architecture principles.*
