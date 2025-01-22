using Microsoft.Extensions.Configuration;

namespace Configuration;

public class csAppConfig
{
    public const string Appsettingfile = "appsettings.json";

    #region Singleton design pattern
    private static csAppConfig _instance = null;
    private static IConfigurationRoot _configuration = null;
    #endregion

    #region  ConfigurationDataStructure

    private  static csConfAdress _address = new csConfAdress();

    #endregion

    private csAppConfig()
    {
        var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory());
        builder = builder.AddJsonFile(Appsettingfile, optional: true, reloadOnChange: true);
        _configuration = builder.Build();

        _configuration.Bind("Address", _address);

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

    public static string Author => ConfigurationRoot["Author"];
    public static string Country => ConfigurationRoot["Country"];

     public static csConfAdress Address
    {
        get
        {
            if (_instance == null)
            {
                _instance = new csAppConfig();
            }
            return _address;
        }
    }

}


public class csConfAdress
{
   public string Street {get; set;}
   
   public int Zip {get; set;}
   
   public string City {get; set;}
}
