using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public class csLocation : ISeed<csLocation> , ILocation
{
  public virtual Guid LocationId { get; set; }
  public virtual string Country { get; set; }  
  public virtual string City { get; set; }
  
  public virtual bool Seeded { get; set; } = false;

    
    public virtual csLocation Seed(csSeedGenerator _seed)
    {
        Seeded = true;
        LocationId = Guid.NewGuid();
        Country = _seed.Country;
        City = _seed.City(this.Country);
        
        return this;
    }
}