using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public interface IUser
{

    public Guid UserId { get; set; }
    public string Name { get; set; }
    public List<IComment> Comments { get; set; }
   
}