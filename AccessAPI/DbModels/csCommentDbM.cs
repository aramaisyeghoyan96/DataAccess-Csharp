using System.ComponentModel.DataAnnotations;
using Models;
using Seido.Utilities.SeedGenerator;

namespace DbModels;

public class csCommentDbM : csComment, ISeed<csCommentDbM>
{
   [Key]
   public override Guid CommentId { get; set;}

   public override csCommentDbM Seed (csSeedGenerator _seeder)
    {
        base.Seed(_seeder);

        return this;
    }
}
  