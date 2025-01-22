using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace DbModels;

public class csCommentDbM : csComment, ISeed<csCommentDbM>
{
   [Key]
   public override Guid CommentId { get; set;}

   [NotMapped]
   public override IUser User { get => UserDbM; set => new NotImplementedException(); }
   
   [JsonIgnore]
   public virtual csUserDbM UserDbM { get; set;} = null;
   
    [NotMapped]
   public override IAttraction Attraction { get => AttractionDbM; set => new NotImplementedException(); }
    
    [JsonIgnore]
   public virtual csAttractionDbM AttractionDbM { get; set;} = null;

//    [NotMapped] // Lägg till detta för att dölja Seeded
//     public override bool Seeded { get; set; } = false;


   public override csCommentDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }
}
  