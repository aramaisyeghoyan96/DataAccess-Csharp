using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DbModels;

public class csAttractionDbM : csAttraction, ISeed<csAttractionDbM>
{
   [Key]
   public override Guid AttractionId { get; set;}

   [NotMapped]
   public override List<IComment> Comments { get => CommentDbM?.ToList<IComment>(); set => throw new NotImplementedException(); }

   [JsonIgnore]  
   public List <csCommentDbM> CommentDbM { get; set; } = null;

   [NotMapped]
   public override ILocation Locations { get => LocationDbM; set => throw new NotImplementedException(); }
 
   [JsonIgnore]  
   public virtual csLocationDbM LocationDbM { get; set; } = null;

//    [NotMapped] // Lägg till detta för att dölja Seeded
//     public override bool Seeded { get; set; } = false;
   
   public override csAttractionDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }
}


  