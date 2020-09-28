# demo-contact-api

## Overview
This is a .Net Core API for managing the contact information of employees and their families. It uses SQL Server as the data store.

## Running the API
1. Clone or download this repository
2. Open the solution file in Visual Studio
3. Edit the `appsettings.Development.json` file to configure a database connection string that will work with your development SQL Server (default: local server with DB named ContactsApi)
4. Create the database using one of the following approaches
    * **Visual Studio:** In the Package Manager Console run `Update-Database`
    * **Command Line:** Run `dotnet ef database update` in the `src/ContactsAPI.Web` directory. The EF Core CLI must be installed (see: https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli#create-the-database)
5. Run the solution. A browser should open to https://localhost:44365/swagger
6. (optional) Run the test data creation script `src/ContactsAPI.Web/Scripts/create_test_data.ps1` in PowerShell once to populate a few contacts.

## Tech debt/issues
The time constraints of this project have resulted in many weak areas.
1. API should have a separate model from database. 
    * Hypermedia links instead of IDs (HATEOAS)
    * verbose/nonverbose models
    * Use AutoMapper or similar library
2. No logging currently
3. Poor validation and error handling
4. No unit or integration testing.
5. Only simple Windows auth. Is CORS needed? Bearer token flow?
6. Address entity has multiple issues:
    * No way to update currently. Should create a separate controller.
    * Updates could create orphaned addresses. How will these be cleaned up?
    * Should address type be it's own table?
7. Should we add pagination for last name search?
8. Better documentation of API
9. Improve test data creation script
