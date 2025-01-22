using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalsService2: IAnimalsService {

        private const string seedSource = "./friends-seeds2.json";
        private List<IAnimal> _animals;

        public List<IAnimal> AfricanAnimals(int _count)
        {

            return _animals;
        }

        public void Seed (int _count) => throw new NotImplementedException();
        
        public csAnimalsService2()
        {
            var fn = Path.GetFullPath(seedSource);
            var _seeder = new csSeedGenerator(fn);

            //var animal = new csAnimal().Seed(_seeder);
             _animals = _seeder.ItemsToList<csAnimal>(5).ToList<IAnimal>();
        }
}