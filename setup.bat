@echo off
echo ========================================
echo DreamJob Application Setup
echo ========================================
echo.

echo Step 1: Checking .NET SDK...
dotnet --version
if %errorlevel% neq 0 (
    echo ERROR: .NET SDK not found! Please install .NET 8.0 or higher.
    echo Download from: https://dotnet.microsoft.com/download
    pause
    exit /b 1
)
echo .NET SDK found!
echo.

echo Step 2: Checking Node.js...
node --version
if %errorlevel% neq 0 (
    echo ERROR: Node.js not found! Please install Node.js 18 or higher.
    echo Download from: https://nodejs.org/
    pause
    exit /b 1
)
echo Node.js found!
echo.

echo Step 3: Installing Angular dependencies...
cd DreamJob.Client
call npm install
if %errorlevel% neq 0 (
    echo ERROR: Failed to install npm packages!
    pause
    exit /b 1
)
cd ..
echo Dependencies installed!
echo.

echo Step 4: Setting up database...
cd DreamJob.Server
dotnet ef database update
if %errorlevel% neq 0 (
    echo WARNING: Database migration may have failed.
    echo The database will be created automatically on first run.
)
cd ..
echo.

echo ========================================
echo Setup Complete!
echo ========================================
echo.
echo To run the application:
echo   1. Open DreamJob.sln in Visual Studio 2022
echo   2. Press F5 to run
echo.
echo OR run manually:
echo   Terminal 1: cd DreamJob.Server ^&^& dotnet run
echo   Terminal 2: cd DreamJob.Client ^&^& npm start
echo.
pause
