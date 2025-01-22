using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public class csUser : ISeed<csUser> , IUser
{

    public Guid UserId { get; set; }
    public string Name { get; set; }
    public List<csComment> Comments { get; set; } = new List<csComment>();
   

    public bool Seeded { get; set; } = false;
    public csUser Seed(csSeedGenerator _seeder)
    {
        
        Seeded = true;
        UserId = Guid.NewGuid();
        Name = _seeder.FullName;


        
        return this;
    }
}