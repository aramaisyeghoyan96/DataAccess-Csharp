using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csAttractionDbM : csAttraction, ISeed<csAttractionDbM>
{
   [Key]
   public override Guid AttractionId { get; set;}

//    [NotMapped]
//    public override List<IComment> Comments { get => csCommentDbM?.ToList<>(); set => throw new NotImplementedException(); }



   public override csAttractionDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);

        return this;
    }
}


  