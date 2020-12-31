cd ./src/TimeTracker.Persistence
$env:ASPNETCORE_ENVIRONMENT='Development'
dotnet ef migrations add 'Initial'
