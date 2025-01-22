using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csAttraction :ISeed<csAttraction> , IAttraction
{
   public Guid AttractionId { get; set; }
   public string Name { get; set; }

   public string Description { get; set; }

   public csLocation Location{ get; set; }

   public List<csComment> Comments { get; set; } = new List<csComment>();


    #region seeder
    public bool Seeded { get; set; } = false;

    public csAttraction Seed (csSeedGenerator _seeder)
    {
        var newLocation = new csLocation();
        

        Seeded = true;
        AttractionId = Guid.NewGuid();
        Name = _seeder.LatinWords(1).ToString();
        Description = _seeder.LatinSentence;
        Location = newLocation.Seed(_seeder);
       
        

        return this;
    }
    #endregion
    
}