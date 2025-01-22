using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IAttraction 
{
   public Guid AttractionId { get; set; }
   public string Name { get; set; }

   public string Title { get; set; }

   public string Description { get; set; }

   public string Category { get; set; }

   public ILocation Locations{ get; set; }

   public List<IComment> Comments { get; set; } 


}