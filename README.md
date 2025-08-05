# DALUMPINES_08052025
Simple web application that allows users to upload and watch videos

# App.API

A .NET 8 Web API for managing video files, categories, and thumbnails. The project uses Entity Framework Core for data access, MediatR for CQRS, and supports file uploads and video metadata management.

## Features

- Upload and manage video files
- Assign categories to videos (many-to-many)
- Generate and associate thumbnails with videos
- RESTful API endpoints with Swagger UI
- CQRS pattern with MediatR
- Unit and integration tests using NUnit, Moq, and Bogus

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (SQL Server & InMemory)
- MediatR
- Swashbuckle (Swagger)
- FluentValidation
- MediaToolkit (for video processing)
- NUnit, Moq, Bogus (for testing)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (if using SQL backend)

### Setup

1. Clone the repository
	: https://github.com/ralphdalumpines/DALUMPINES_08052025.git
2. Update the connection string in `appsettings.json`:
	: "ConnectionStrings": { "DefaultConnection": "Server=YOUR_SERVER;Database=AppDb;Trusted_Connection=True;" }
3. Run database migrations or scripts (if needed)
4. Build and run the API: with App.API as the startup item and run using https
5. Open Swagger UI at https://localhost:7266/swagger/index.html to explore the API.

## Project Structure

- `App.API` - Main Web API project
- `App.APITests` - Test project (unit/integration tests)
- `Model` - Entity Framework Core models and DbContext
- `Implementation` - CQRS handlers and commands/queries

## Contributing

Contributions are welcome! Please open issues or submit pull requests.

## License

This project is licensed under the MIT License.