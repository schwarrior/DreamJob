@echo off
echo ========================================
echo DreamJob Application Setup
echo ========================================
echo.

REM Check if we're in the right directory
if not exist "DreamJob.sln" (
    echo ERROR: Please run this script from the DreamJob root directory
    echo Current directory: %CD%
    pause
    exit /b 1
)

echo Step 1: Installing Angular dependencies...
cd DreamJob.Client
call npm install
if %errorlevel% neq 0 (
    echo ERROR: Failed to install Angular dependencies
    pause
    exit /b 1
)
cd ..

echo.
echo Step 2: Restoring .NET packages...
cd DreamJob.Server
call dotnet restore
if %errorlevel% neq 0 (
    echo ERROR: Failed to restore .NET packages
    pause
    exit /b 1
)

echo.
echo Step 3: Building the backend...
call dotnet build
if %errorlevel% neq 0 (
    echo ERROR: Failed to build backend
    pause
    exit /b 1
)

echo.
echo Step 4: Creating database...
echo Note: This will create migrations and update the database
call dotnet ef migrations add InitialCreate
call dotnet ef database update
if %errorlevel% neq 0 (
    echo WARNING: Database setup had issues. The app will try to create it on first run.
)

cd ..

echo.
echo ========================================
echo Setup Complete!
echo ========================================
echo.
echo To run the application:
echo.
echo Option 1 - Open in Visual Studio:
echo   1. Open DreamJob.sln
echo   2. Set DreamJob.Server as startup project
echo   3. Press F5
echo.
echo Option 2 - Run from command line:
echo   Terminal 1: cd DreamJob.Server ^&^& dotnet run
echo   Terminal 2: cd DreamJob.Client ^&^& npm start
echo.
echo The application will be available at:
echo   Backend API: https://localhost:7178
echo   Frontend: http://localhost:4200
echo.
pause
