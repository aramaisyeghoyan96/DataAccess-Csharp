
using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAttractionService : IAttractionService {

        private const string seedSource = "./friends-seeds1.json";

        public List<csAttraction> Attractions(int _count)
        {
            var _seeder = new csSeedGenerator(seedSource);
            
            var attractions = _seeder.ItemsToList<csAttraction>(_count);
            foreach (var attraction in attractions)
            {
                attraction.Comments = _seeder.ItemsToList<csComment>(_seeder.Next(0,10));
            }
            return attractions;
        }

}