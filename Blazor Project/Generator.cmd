@echo off
setlocal EnableDelayedExpansion

:: Get the folder name from the current directory where the script is executed
set "folderPath=%cd%"
for %%F in ("%folderPath%") do set "folderName=%%~nxF"

:: Check if the folder name is empty (this should never happen unless you're not in a folder)
if "%folderName%"=="" (
    echo Failed to determine the folder name. The script must be executed from a folder.
    pause
    goto :end
)

:: Display the project name
echo Using folder name "%folderName%" as the project name.

:: Create the solution file
echo Creating solution file for project: %folderName%
dotnet new sln -n "%folderName%"
if %errorlevel% neq 0 (
    echo Failed to create solution.
    pause
    goto :end
)
echo Solution "%folderName%" created successfully.

:: Create the Model project (Class Library)
echo Creating Model project (Class Library)...
dotnet new classlib -o "%folderPath%\%folderName%.Model"
if %errorlevel% neq 0 (
    echo Failed to create Model project.
    pause
    goto :end
)
echo Model project created successfully.

:: Create the Data project (Class Library)
echo Creating Data project (Class Library)...
dotnet new classlib -o "%folderPath%\%folderName%.Data"
if %errorlevel% neq 0 (
    echo Failed to create Data project.
    pause
    goto :end
)
echo Data project created successfully.

:: Create the UI project (Blazor Server)
echo Creating UI project (Blazor Server)...
dotnet new blazorserver -o "%folderPath%\%folderName%.UI"
if %errorlevel% neq 0 (
    echo Failed to create UI project.
    pause
    goto :end
)
echo UI project created successfully.

:: Create the API project (ASP.NET Core Web API)
echo Creating API project (ASP.NET Core Web API)...
dotnet new webapi -o "%folderPath%\%folderName%.API"
if %errorlevel% neq 0 (
    echo Failed to create API project.
    pause
    goto :end
)
echo API project created successfully.

:: Add the projects to the solution
echo Adding projects to the solution...
dotnet sln "%folderPath%\%folderName%.sln" add "%folderPath%\%folderName%.Model\%folderName%.Model.csproj"
dotnet sln "%folderPath%\%folderName%.sln" add "%folderPath%\%folderName%.Data\%folderName%.Data.csproj"
dotnet sln "%folderPath%\%folderName%.sln" add "%folderPath%\%folderName%.UI\%folderName%.UI.csproj"
dotnet sln "%folderPath%\%folderName%.sln" add "%folderPath%\%folderName%.API\%folderName%.API.csproj"
if %errorlevel% neq 0 (
    echo Failed to add projects to the solution.
    pause
    goto :end
)
echo Projects added to the solution successfully.

:: Add NuGet dependencies
echo Adding NuGet dependencies to Blazor UI...
dotnet add "%folderPath%\%folderName%.UI\%folderName%.UI.csproj" package ChartJs.Blazor --version 1.1.0
dotnet add "%folderPath%\%folderName%.UI\%folderName%.UI.csproj" package Microsoft.AspNetCore.Components.WebAssembly --version 8.0.0
if %errorlevel% neq 0 (
    echo Failed to add NuGet dependencies to UI project.
    pause
    goto :end
)
echo NuGet dependencies added to Blazor UI.

echo Adding NuGet dependencies to Data project...
dotnet add "%folderPath%\%folderName%.Data\%folderName%.Data.csproj" package Dapper --version 2.1.66
dotnet add "%folderPath%\%folderName%.Data\%folderName%.Data.csproj" package Microsoft.Data.SqlClient --version 6.0.1
dotnet add "%folderPath%\%folderName%.Data\%folderName%.Data.csproj" package System.Data.SqlClient --version 4.8.0
if %errorlevel% neq 0 (
    echo Failed to add NuGet dependencies to Data project.
    pause
    goto :end
)
echo NuGet dependencies added to Data project.

echo Adding NuGet dependencies to API project...
dotnet add "%folderPath%\%folderName%.API\%folderName%.API.csproj" package Microsoft.Data.SqlClient --version 6.0.1
dotnet add "%folderPath%\%folderName%.API\%folderName%.API.csproj" package Microsoft.OpenApi --version 1.6.23
dotnet add "%folderPath%\%folderName%.API\%folderName%.API.csproj" package Swashbuckle.AspNetCore --version 8.0.0
if %errorlevel% neq 0 (
    echo Failed to add NuGet dependencies to API project.
    pause
    goto :end
)
echo NuGet dependencies added to API project.

:: Add references between projects
echo Adding references between projects...
dotnet add "%folderPath%\%folderName%.UI\%folderName%.UI.csproj" reference "%folderPath%\%folderName%.Model\%folderName%.Model.csproj"
dotnet add "%folderPath%\%folderName%.Data\%folderName%.Data.csproj" reference "%folderPath%\%folderName%.Model\%folderName%.Model.csproj"
dotnet add "%folderPath%\%folderName%.API\%folderName%.API.csproj" reference "%folderPath%\%folderName%.Data\%folderName%.Data.csproj"
dotnet add "%folderPath%\%folderName%.API\%folderName%.API.csproj" reference "%folderPath%\%folderName%.Model\%folderName%.Model.csproj"
if %errorlevel% neq 0 (
    echo Failed to add references between projects.
    pause
    goto :end
)
echo References added successfully.

:: Restore the solution
echo Restoring the solution...
dotnet restore "%folderPath%\%folderName%.sln"
if %errorlevel% neq 0 (
    echo Failed to restore the solution.
    pause
    goto :end
)
echo Solution restored successfully.

:: Final output
echo All projects have been created, added to the solution, and the necessary NuGet packages and references have been configured.

:: Write the result to a file
echo All steps completed successfully > result.txt
echo Results have been written to result.txt

:: Keep the window open
:end
pause
endlocal
