using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csComment : ISeed<csComment> , IComment
{
    public Guid CommentId {get; set;} = Guid.NewGuid();

    public string userText  { get; set; }
    public int Rating { get; set; }

    public DateTime Date { get; set; }

    public csUser User { get; set; }

    public bool Seeded { get; set; } = false;
    public csAttraction Attraction { get; set; } //Navigation property
    
    List<string> userComments = new List<string>
    {
        "Fantastic experience! The exhibits were interactive and fun.",
        "Overrated. Crowded and way too expensive for what it offers.",
        "Loved it! The architecture was stunning.",
        "Disappointing. Long lines and nothing special to see.",
        "Perfect for families. Our kids had a blast!",
        "Not worth the hype. The place looks run-down.", 
        "Beautiful scenery! A must-see if you're in the area.", 
        "Terrible service. The staff was rude and unhelpful.", 
        "So peaceful. Great spot to relax and take in nature.", 
        "Waste of time. The whole place feels outdated." 
    };

    public csComment Seed(csSeedGenerator _seeder)
    {
        var newUser = new csUser();

        
        Seeded = true;
        
        CommentId = Guid.NewGuid();
        userText = userComments[_seeder.Next(0, userComments.Count)];
        Rating = _seeder.Next(1,6);
        User = newUser.Seed(_seeder);
        Date = _seeder.DateAndTime(2002, 2024);




        return this;
    }

}