using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csLocationDbM : csLocation, ISeed<csLocationDbM>
{
   [Key]
   public override Guid LocationId { get; set;}

   public override csLocationDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }

    
}