using System.Security.Cryptography.X509Certificates;
using Configuration;
using Seido.Utilities.SeedGenerator;

namespace Models;


public interface ILocation 
{
  public Guid LocationId { get; set; }
  public string Country { get; set; }  
  public string City { get; set; }
  
  

    
}