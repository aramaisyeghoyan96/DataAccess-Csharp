using Microsoft.Extensions.Configuration;
namespace Configuration;

  public class csAppConfig
{
    public const string AppSettingFile = "appsettings.json";
    #region Singleton
    private static csAppConfig _instance = null;
    private static IConfigurationRoot _configuration = null;
    #endregion

    private csAppConfig()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

        builder = builder.AddJsonFile(AppSettingFile, optional: true, reloadOnChange: true);
        _configuration = builder.Build();
    }

    public static IConfigurationRoot ConfigurationRoot
    {
        get 
        {
            if (_instance == null)
            {
                _instance = new csAppConfig();
            }
            return _configuration;
        }
    }
    public static string Author => _configuration["Author"];
}
