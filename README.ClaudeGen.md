# DreamJob

A full-stack web application for designing and customizing your dream job posting. Built with Angular 19 and ASP.NET Core with Entity Framework.

## Features

- **Job Title Management**: Edit and customize the job title
- **Skills Selection**: Choose from 30+ common technical skills or add custom skills
- **Job Details Editor**: Customize the full job description
- **Real-time Updates**: All changes are persisted to a SQL Server database
- **Modern UI**: Beautiful, responsive design inspired by professional job boards

## Architecture

### DreamJob.Client (Angular 19)
- Standalone Angular components with signals
- Reactive forms for editing
- HttpClient for API communication
- Professional, responsive UI with modern CSS

### DreamJob.Server (ASP.NET Core .NET 8.0)
- RESTful Web API
- Entity Framework Core with SQL Server
- Code-First database migrations
- CORS support for development

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [Node.js](https://nodejs.org/) (v18 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## Getting Started

### 1. Clone or Download the Repository

```bash
git clone <your-repo-url>
cd DreamJob
```

### 2. Set Up the Database

The application uses Entity Framework Code-First migrations. The database will be created automatically on first run, but you can also create it manually:

```bash
cd DreamJob.Server
dotnet ef database update
```

If you need to modify the connection string, edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DreamJobDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Install Angular Dependencies

```bash
cd DreamJob.Client
npm install
```

### 4. Run the Application

#### Option A: Using Visual Studio
1. Open `DreamJob.sln` in Visual Studio 2022
2. Set `DreamJob.Server` as the startup project
3. Press F5 to run

The application will:
- Start the ASP.NET Core server
- Automatically launch the Angular dev server
- Open your browser to the application

#### Option B: Using Command Line

**Terminal 1 - Run the API Server:**
```bash
cd DreamJob.Server
dotnet run
```

**Terminal 2 - Run the Angular Dev Server:**
```bash
cd DreamJob.Client
npm start
```

Then open your browser to `http://localhost:4200`

### 5. Build for Production

To build the Angular app for production and have it served by the ASP.NET Core server:

```bash
cd DreamJob.Client
npm run build
```

This will build the Angular app into `DreamJob.Server/wwwroot`. Then run:

```bash
cd ../DreamJob.Server
dotnet run
```

Access the app at `https://localhost:5001` (or the port shown in the console).

## Project Structure

```
DreamJob/
├── DreamJob.sln                 # Visual Studio solution file
├── DreamJob.Server/             # ASP.NET Core backend
│   ├── Controllers/             # API controllers
│   │   └── DreamJobsController.cs
│   ├── Data/                    # Entity Framework DbContext
│   │   └── DreamJobContext.cs
│   ├── Models/                  # Data models and DTOs
│   │   ├── DreamJob.cs
│   │   ├── JobSkill.cs
│   │   └── DreamJobDto.cs
│   ├── Program.cs               # Application entry point
│   ├── appsettings.json         # Configuration
│   └── DreamJob.Server.csproj   # Project file
│
└── DreamJob.Client/             # Angular 19 frontend
    ├── src/
    │   ├── app/
    │   │   ├── models/          # TypeScript models
    │   │   │   └── dream-job.model.ts
    │   │   ├── services/        # API services
    │   │   │   └── dream-job.service.ts
    │   │   ├── app.component.ts # Main component
    │   │   ├── app.component.html
    │   │   └── app.component.css
    │   ├── styles.css           # Global styles
    │   └── index.html
    ├── angular.json             # Angular CLI configuration
    ├── package.json             # npm dependencies
    └── DreamJob.Client.esproj   # JavaScript project file
```

## API Endpoints

### GET /api/dreamjobs
Get all dream jobs

### GET /api/dreamjobs/{id}
Get a specific dream job

### POST /api/dreamjobs
Create a new dream job
```json
{
  "title": "Senior Developer",
  "jobDetails": "Description...",
  "skills": ["C#", "Angular", "SQL"]
}
```

### PUT /api/dreamjobs/{id}
Update an existing dream job
```json
{
  "title": "Updated Title",
  "jobDetails": "Updated description...",
  "skills": ["C#", "React", "MongoDB"]
}
```

### DELETE /api/dreamjobs/{id}
Delete a dream job

### GET /api/dreamjobs/common-skills
Get list of common technical skills

## Database Schema

### DreamJobs Table
- Id (int, PK)
- Title (nvarchar(200))
- JobDetails (nvarchar(max))
- CreatedDate (datetime2)
- LastModifiedDate (datetime2)

### JobSkills Table
- Id (int, PK)
- Name (nvarchar(100))
- IsCustom (bit)
- DreamJobId (int, FK)

## Technologies Used

### Frontend
- Angular 19 (Standalone Components)
- TypeScript
- RxJS
- CSS3 with modern gradients and animations

### Backend
- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server
- RESTful API design

## Customization

### Adding More Common Skills
Edit `DreamJobsController.cs` and add skills to the `CommonSkills` list:

```csharp
private static readonly List<string> CommonSkills = new()
{
    "C#", "Java", "Python", "Your-New-Skill"
    // ... more skills
};
```

### Changing the Default Dream Job
Edit the seed data in `DreamJobContext.cs` in the `OnModelCreating` method.

### Styling
Modify `app.component.css` to change colors, fonts, and layout. The color scheme uses CSS gradients that can be easily customized.

## Troubleshooting

### Database Connection Issues
- Ensure SQL Server is running
- Check the connection string in `appsettings.json`
- Try running `dotnet ef database update` manually

### Angular Build Issues
- Delete `node_modules` folder and run `npm install` again
- Clear npm cache: `npm cache clean --force`
- Ensure Node.js version is compatible (v18+)

### CORS Errors
- Make sure the Angular dev server is running on port 4200
- Check CORS configuration in `Program.cs`

## Future Enhancements

- User authentication and authorization
- Multiple job postings per user
- Job posting templates
- Export to PDF
- Share links for job postings
- Job posting analytics

## License

This project is provided as-is for educational and portfolio purposes.

## Support

For issues, questions, or contributions, please open an issue on the project repository.
