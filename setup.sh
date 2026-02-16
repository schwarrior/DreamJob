#!/bin/bash

echo "========================================"
echo "DreamJob Application Setup"
echo "========================================"
echo ""

echo "Step 1: Checking .NET SDK..."
if ! command -v dotnet &> /dev/null; then
    echo "ERROR: .NET SDK not found! Please install .NET 8.0 or higher."
    echo "Download from: https://dotnet.microsoft.com/download"
    exit 1
fi
dotnet --version
echo ".NET SDK found!"
echo ""

echo "Step 2: Checking Node.js..."
if ! command -v node &> /dev/null; then
    echo "ERROR: Node.js not found! Please install Node.js 18 or higher."
    echo "Download from: https://nodejs.org/"
    exit 1
fi
node --version
echo "Node.js found!"
echo ""

echo "Step 3: Installing Angular dependencies..."
cd DreamJob.Client
npm install
if [ $? -ne 0 ]; then
    echo "ERROR: Failed to install npm packages!"
    exit 1
fi
cd ..
echo "Dependencies installed!"
echo ""

echo "Step 4: Setting up database..."
cd DreamJob.Server
dotnet ef database update 2>/dev/null
if [ $? -ne 0 ]; then
    echo "WARNING: Database migration may have failed."
    echo "The database will be created automatically on first run."
fi
cd ..
echo ""

echo "========================================"
echo "Setup Complete!"
echo "========================================"
echo ""
echo "To run the application:"
echo "  Terminal 1: cd DreamJob.Server && dotnet run"
echo "  Terminal 2: cd DreamJob.Client && npm start"
echo ""
echo "Then open your browser to http://localhost:4200"
echo ""
