using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
namespace DbModels;

public class csUserDbM : csUser, ISeed<csUserDbM>
{
   [Key]
   public override Guid UserId { get; set; }

    [NotMapped]
    public override List<IComment> Comments { get => CommentsDbM?.ToList<IComment>(); set => new NotImplementedException(); }
    
    [JsonIgnore]
    public virtual List<csCommentDbM> CommentsDbM {get; set;} = null;

    // [NotMapped] // Lägg till detta för att dölja Seeded
    // public override bool Seeded { get; set; } = false;
    
    public override csUserDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);
        return this;
    }
}