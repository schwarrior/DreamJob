# DreamJob - Full Stack Job Portal Application

A modern full-stack job portal application built with Angular 17 and ASP.NET Core 8.0.

## Architecture

### Solution Structure
```
DreamJob/
├── DreamJob.sln                    # Visual Studio Solution
├── DreamJob.Server/                # ASP.NET Core Backend
│   ├── Controllers/                # API Controllers
│   ├── Data/                       # Entity Framework DbContext
│   ├── Models/                     # Entity Models
│   └── Program.cs                  # Application Entry Point
└── DreamJob.Client/                # Angular Frontend
    ├── src/
    │   ├── app/
    │   │   ├── components/        # Angular Components
    │   │   ├── services/          # API Services
    │   │   └── models/            # TypeScript Models
    │   └── environments/          # Environment Configs
    └── angular.json               # Angular Configuration
```

## Features

### Backend (ASP.NET Core)
- RESTful Web API with Entity Framework Core
- Code-First database approach with SQL Server
- Three main entities: Jobs, Companies, Applications
- Automatic database migrations
- Swagger/OpenAPI documentation
- CORS support for Angular development

### Frontend (Angular)
- Modern Angular 17 with standalone components
- Responsive UI design
- Multiple views: Home, Jobs, Job Details, Companies, Applications
- HTTP services for API communication
- Routing with Angular Router
- TypeScript strong typing

## Prerequisites

- .NET 8.0 SDK
- Node.js 18+ and npm
- SQL Server or SQL Server LocalDB
- Visual Studio 2022 or VS Code

## Setup Instructions

### 1. Clone or Copy to Windows

Copy the entire DreamJob folder to:
```
C:\Dev\SC\GitHub\schwarrior\DreamJob
```

### 2. Database Setup

The application uses Entity Framework Code-First migrations. The database will be created automatically on first run with connection string:
```
Server=(localdb)\mssqllocaldb;Database=DreamJobDb;Trusted_Connection=true;MultipleActiveResultSets=true
```

To manually create the database:
```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Server
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Install Angular Dependencies

```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Client
npm install
```

### 4. Build and Run

#### Option A: Using Visual Studio
1. Open `DreamJob.sln`
2. Set `DreamJob.Server` as the startup project
3. Press F5 to run

#### Option B: Using Command Line

Terminal 1 - Backend:
```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Server
dotnet run
```

Terminal 2 - Frontend (Development):
```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Client
npm start
```

The backend will run on `https://localhost:7178` (or similar)
The Angular dev server will run on `http://localhost:4200`

### 5. Build for Production

To build the Angular app into the ASP.NET static files:

```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Client
npm run build -- --configuration production
```

Then copy the contents of `DreamJob.Client/dist/dream-job-client/browser/` to `DreamJob.Server/wwwroot/`

Or simply publish the ASP.NET project, which will automatically build Angular:
```bash
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Server
dotnet publish -c Release
```

## API Endpoints

### Jobs
- `GET /api/jobs` - Get all active jobs
- `GET /api/jobs/{id}` - Get job by ID
- `POST /api/jobs` - Create new job
- `PUT /api/jobs/{id}` - Update job
- `DELETE /api/jobs/{id}` - Delete job

### Companies
- `GET /api/companies` - Get all companies
- `GET /api/companies/{id}` - Get company by ID
- `POST /api/companies` - Create new company
- `PUT /api/companies/{id}` - Update company
- `DELETE /api/companies/{id}` - Delete company

### Applications
- `GET /api/applications` - Get all applications
- `GET /api/applications/{id}` - Get application by ID
- `GET /api/applications/ByJob/{jobId}` - Get applications by job
- `POST /api/applications` - Submit application
- `PUT /api/applications/{id}` - Update application
- `DELETE /api/applications/{id}` - Delete application

## Database Schema

### Jobs Table
- Id (int, PK)
- Title (nvarchar(200))
- Description (nvarchar(max))
- CompanyId (int, FK)
- Location (nvarchar)
- Salary (decimal)
- PostedDate (datetime)
- IsActive (bit)

### Companies Table
- Id (int, PK)
- Name (nvarchar(200))
- Description (nvarchar(1000))
- Location (nvarchar)
- Website (nvarchar)

### Applications Table
- Id (int, PK)
- JobId (int, FK)
- ApplicantName (nvarchar(200))
- ApplicantEmail (nvarchar(200))
- Resume (nvarchar)
- CoverLetter (nvarchar)
- AppliedDate (datetime)
- Status (nvarchar)

## Development

### Running in Development Mode

For development, run both projects separately:

1. Backend with hot reload:
```bash
cd DreamJob.Server
dotnet watch run
```

2. Frontend with hot reload:
```bash
cd DreamJob.Client
npm start
```

The Angular proxy configuration will forward API requests to the backend.

### Adding New Features

1. **Add a new entity**: Create model in `Models/`, update `DbContext`, create migration
2. **Add a new API endpoint**: Create/update controller in `Controllers/`
3. **Add a new page**: Create component in `src/app/components/`, add route to `app.routes.ts`
4. **Add a new service**: Create service in `src/app/services/`

## Troubleshooting

### CORS Issues
If you get CORS errors during development, ensure the Angular dev server is running on port 4200 and the backend CORS policy includes it.

### Database Connection Issues
Check that SQL Server LocalDB is installed and running. Update the connection string in `appsettings.json` if needed.

### Angular Build Issues
Delete `node_modules` and `package-lock.json`, then run `npm install` again.

### Port Conflicts
If ports 7178 or 4200 are in use, update:
- Backend: `Properties/launchSettings.json`
- Frontend: `angular.json` serve options

## Technologies Used

### Backend
- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- Swagger/OpenAPI

### Frontend
- Angular 17
- TypeScript 5.2
- RxJS 7.8
- Angular Router

## License

MIT License - Feel free to use this project for learning and development.

## Support

For issues or questions, please create an issue in the repository.


