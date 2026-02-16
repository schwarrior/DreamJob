# Quick Start Guide

Get DreamJob running in 5 minutes!

## Prerequisites Check

Before starting, ensure you have:
- ✅ .NET 8.0 SDK installed
- ✅ Node.js v18+ installed  
- ✅ SQL Server (LocalDB, Express, or Full)

## Automated Setup (Recommended)

### Windows
```cmd
setup.bat
```

### Linux/Mac
```bash
chmod +x setup.sh
./setup.sh
```

## Manual Setup (3 Steps)

### Step 1: Install Dependencies
```bash
cd DreamJob.Client
npm install
```

### Step 2: Setup Database (Optional)
```bash
cd ../DreamJob.Server
dotnet ef database update
```
*Note: Database will auto-create on first run if this step is skipped*

### Step 3: Run the Application

**Option A - Using Visual Studio:**
1. Open `DreamJob.sln`
2. Press F5

**Option B - Using Terminal:**

Terminal 1:
```bash
cd DreamJob.Server
dotnet run
```

Terminal 2:
```bash
cd DreamJob.Client
npm start
```

Open browser to: `http://localhost:4200`

## What You'll See

The application loads with a default "Senior Full Stack Developer" dream job posting. You can:

1. **Edit Title** - Click "Edit" button in the Title pane
2. **Customize Skills** - Click "Edit" in Skills pane to select from 30+ common skills or add custom ones
3. **Modify Details** - Click "Edit" in Details pane to write your dream job description

All changes are saved to the SQL Server database automatically!

## Troubleshooting

### "Connection to database failed"
- Ensure SQL Server is running
- Check connection string in `DreamJob.Server/appsettings.json`

### "npm install fails"
```bash
npm cache clean --force
npm install
```

### "Port already in use"
Change ports in:
- Angular: `DreamJob.Client/angular.json` (default: 4200)
- ASP.NET: `DreamJob.Server/Properties/launchSettings.json` (default: 5225/7225)

## Default Login Credentials

No authentication required! The app loads with ID=1 dream job by default.

## Next Steps

After running:
- Check out the [full README](README.md) for detailed documentation
- Explore the API at `https://localhost:7225/swagger` (when running in Development mode)
- Customize the seed data in `DreamJobContext.cs`

## Support

Issues? Check the [README](README.md) Troubleshooting section or open an issue on GitHub.

---
**Ready to design your dream job? Let's go! 🚀**
