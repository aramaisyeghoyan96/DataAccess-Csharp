using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;

public interface IAttraction 
{
   public Guid AttractionId { get; set; }
   public string Name { get; set; }

   public string Description { get; set; }

   public csLocation Location{ get; set; }

   public List<csComment> Comments { get; set; } 

    
}