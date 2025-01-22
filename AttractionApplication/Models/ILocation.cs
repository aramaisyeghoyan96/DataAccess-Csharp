using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public interface ILocation
    {
        public Guid LocationId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StreetAddress { get; set; }
        public List<IAttraction> Attractions{ get; set; }
    }
}