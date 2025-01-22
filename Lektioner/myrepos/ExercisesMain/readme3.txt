Exercise 3:

1. Create a User-Secret file in Configuration project

    MOVE your own data (Author, Country Address) from appsettings.json to secrets.json
    Modify csAppConfig to read user secrets in addition to appsettings.json
    Run the application and test endpoint Info() and verify the user secrets are read correctly

    
2. Add Logger
    Add a logger to csAdminController. Remember this means:
    a private field, private ILogger<csAdminController> _logger = null;
    a constructor that injects ILogger<csAdminController> logger and sets _logger
    
3. Logg every endpoint call with _logger.LogInformation(...)

4. Run by opening a terminal in AppWebApi and run the program by using 
   dotnet run -lp https

5. Modify appsettings.json so the Console does not log anything from namespace AppWebApi.Controllers


