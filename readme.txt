Stack:
	backend - asp.netcore 3.1
	frontend - angular 12
	db - sql server

Launching the App

Prequisites
  Visual Studio 17 or higher,
  MS SQL server / MS SQL Express Server
  Internet Connection

1. (optionally)

There is a pre-build frontend bundle in ExchangeRatesReader/wwwroot folder. However, it can be rebuild. The most comfortable way is by using
buildFrontend.ps1 script. It checks the required software to build angular app, installs packages and builds the bundles into the wwwroot folder.

2. Configuration (required)

Open the appsettings.json file from the ExchangeRatesReader folder. Replace X with a local SQL Server instance Name. Set the database name. The db will be created and migrated during the first
launch of the application.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=X;Database=Y;Trusted_Connection=True;MultipleActiveResultSets=true"
}


3. Open the solution in local Visual Studio IDE. Launch the app in debug/release mode at the iisexpress server
