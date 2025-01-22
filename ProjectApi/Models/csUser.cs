using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public class csUser : ISeed<csUser> , IUser
{

    public virtual Guid UserId { get; set; }
    public virtual string Name { get; set; }
    public virtual List<IComment> Comments { get; set; } = null;
   

    public virtual bool Seeded { get; set; } = false;
    public virtual csUser Seed(csSeedGenerator _seeder)
    {
        
        Seeded = true;
        UserId = Guid.NewGuid();
        Name = _seeder.FullName;
        return this;
    }
}