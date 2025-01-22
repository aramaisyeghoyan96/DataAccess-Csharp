using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csAttraction :ISeed<csAttraction> , IAttraction
{
   private List<string> attractionCategories = new List<string>()
   {
        "Adventure Sports",
        "Botanical Gardens",
        "Architectural Landmarks",
        "Cultural Villages",
        "Scenic Railways",
        "Wine & Vineyard Tours",
        "Hot Springs & Spas",
        "Music & Performance Venues",
        "Urban Parks",
        "Underground Caves",
        "Film & TV Locations",
        "Aquatic Centers"  
   };
   
   public virtual Guid AttractionId { get; set; } 
   public virtual string Name { get; set; }

   public virtual string Description { get; set; }

   public virtual string Category { get; set; }

   public virtual string Title { get; set; }

   public virtual ILocation Locations{ get; set; }

   public virtual List<IComment> Comments { get; set; } = null;


    #region seeder
    public virtual bool Seeded { get; set; } = false;

    public virtual csAttraction Seed (csSeedGenerator _seeder)
    {
      
        AttractionId = Guid.NewGuid();
        var _name = _seeder.LatinWords(1);
        Category = _seeder.FromList<string>(attractionCategories); 
        Seeded = true;
        Name = _name[0];
        Description = _seeder.LatinSentence;
        Title = _seeder.LastName;
        

        return this;
    }
    #endregion
    
}