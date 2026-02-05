# DreamJob - Quick Start Guide

## Installation Steps

### 1. Prerequisites
Before starting, ensure you have:
- ✅ .NET 8.0 SDK installed
- ✅ Node.js 18+ and npm installed
- ✅ SQL Server or SQL Server LocalDB installed
- ✅ Visual Studio 2022 or VS Code (optional but recommended)

### 2. Extract/Copy Files
Copy the entire DreamJob folder to:
```
C:\Dev\SC\GitHub\schwarrior\DreamJob
```

### 3. Run Setup Script
Open Command Prompt or PowerShell as Administrator and run:
```cmd
cd C:\Dev\SC\GitHub\schwarrior\DreamJob
setup.bat
```

This script will:
- Install all Angular dependencies (npm install)
- Restore .NET packages (dotnet restore)
- Build the backend
- Create the database schema

### 4. Run the Application

#### Using Visual Studio (Recommended):
1. Double-click `DreamJob.sln` to open in Visual Studio
2. Right-click `DreamJob.Server` project → Set as Startup Project
3. Press `F5` to run
4. The browser will open automatically

#### Using Command Line:

**Terminal 1 - Backend:**
```cmd
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Server
dotnet run
```

**Terminal 2 - Frontend:**
```cmd
cd C:\Dev\SC\GitHub\schwarrior\DreamJob\DreamJob.Client
npm start
```

Then open a browser to: `http://localhost:4200`

### 5. Verify Installation

Once running, you should see:
- Home page with featured jobs
- Navigation menu with: Home, Jobs, Companies, My Applications
- Sample data (2 companies and 2 jobs pre-loaded)

## Key URLs

- **Frontend**: http://localhost:4200
- **Backend API**: https://localhost:7178
- **Swagger UI**: https://localhost:7178/swagger

## Common Issues

### Issue: "npm not found"
**Solution**: Install Node.js from https://nodejs.org/

### Issue: "dotnet not found"
**Solution**: Install .NET 8.0 SDK from https://dotnet.microsoft.com/download

### Issue: "Cannot connect to database"
**Solution**: 
1. Check SQL Server LocalDB is installed
2. Update connection string in `DreamJob.Server/appsettings.json`
3. Run migrations manually:
   ```cmd
   cd DreamJob.Server
   dotnet ef database update
   ```

### Issue: Port already in use
**Solution**: 
1. For backend (port 7178): Update `Properties/launchSettings.json`
2. For frontend (port 4200): Update port in `DreamJob.Client/angular.json`

### Issue: CORS errors
**Solution**: Ensure both frontend and backend are running. The proxy configuration should handle this automatically in development.

## Next Steps

1. **Explore the App**: Browse jobs, view companies, submit applications
2. **Check the API**: Visit https://localhost:7178/swagger to see all endpoints
3. **View Database**: Use SQL Server Management Studio or Azure Data Studio to view the created database
4. **Modify Code**: Make changes and see hot-reload in action!

## Project Structure

```
DreamJob/
├── DreamJob.Server/          # Backend API
│   ├── Controllers/          # API endpoints
│   ├── Models/              # Data models
│   ├── Data/                # Database context
│   └── Program.cs           # App configuration
├── DreamJob.Client/          # Frontend UI
│   └── src/
│       ├── app/
│       │   ├── components/  # UI components
│       │   └── services/    # API services
│       └── index.html       # Entry point
└── README.md                # Full documentation
```

## Development Tips

- **Hot Reload**: Changes to both Angular and .NET code will automatically reload
- **Debug**: Use browser DevTools (F12) for frontend, VS debugger for backend
- **API Testing**: Use Swagger UI or Postman to test endpoints
- **Database**: View/edit data using SQL Server Management Studio

## Need Help?

Refer to the main README.md file for:
- Complete API documentation
- Database schema details
- Architecture overview
- Troubleshooting guide

---

**Happy Coding! 🚀**
