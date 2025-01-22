using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IComment
{
    public Guid CommentId {get; set;} 
    public string Comments  { get; set; }
    public int Rating { get; set; }
    public IUser User { get; set; }

    public IAttraction Attraction { get; set; } //Navigation property

}