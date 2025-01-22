using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public class csLocation : ISeed<csLocation> , ILocation
{
  public Guid LocationId { get; set; }
  public string Country { get; set; }  
  public string City { get; set; }
  
  public bool Seeded { get; set; } = false;

    
    public csLocation Seed(csSeedGenerator _seed)
    {
        Seeded = true;
        LocationId = Guid.NewGuid();
        Country = _seed.Country;
        City = _seed.City(this.Country);
        
        return this;
    }
}