using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csUserDbM : csUser, ISeed<csUserDbM>
{
   [Key]
   public override Guid UserId { get; set; }

   public override csUserDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }
}