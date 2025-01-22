using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IComment
{
    public Guid CommentId {get; set;} 

    public string userText  { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }

    public csUser User { get; set; }

    public csAttraction Attraction { get; set; } //Navigation property


   

}