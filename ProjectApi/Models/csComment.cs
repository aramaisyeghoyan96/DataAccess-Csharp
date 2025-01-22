using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csComment : ISeed<csComment> , IComment
{
    public virtual Guid CommentId {get; set;} 

    public virtual string Comments { get; set; }
    public virtual int Rating { get; set; }

    public virtual IUser User { get; set; }

    public virtual IAttraction Attraction { get; set; } //Navigation property

    public virtual bool Seeded { get; set; } = false;
    
    public virtual csComment Seed(csSeedGenerator _seeder)
    {
        

        
        Seeded = true;
        
        CommentId = Guid.NewGuid();
        Comments = _seeder.LatinSentence;
        Rating = _seeder.Next(1,6);        
        return this;
    }

}