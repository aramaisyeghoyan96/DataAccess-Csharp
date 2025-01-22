using System.ComponentModel.DataAnnotations;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public class csComment : ISeed<csComment>
{
    [Key]
    public Guid CommentId {get; set;} = Guid.NewGuid();
    public string Comment { get; set; }
    public DateTime Date { get; set; }
    public bool Seeded { get; set; } = false;

    //Navigation props
    public csAttraction Attraction { get; set; }

    public csComment Seed(csSeedGenerator _seeder)
    {
        Seeded = true;
        Comment = _seeder.LatinSentence;
        Date = _seeder.DateAndTime(2023, 2024);

        return this;
    }
}