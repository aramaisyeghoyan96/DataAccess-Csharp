using Configuration;
using Models;
using DbContext;
using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAnimalServiceDb: IAnimalsService {

        private const string seedSource = "./friends-seeds1.json";

        public List<IAnimal> AfricanAnimals(int _count)
        {
            using (var db = csMainDbContext.DbContext("sysadmin"))
            {
                var animals = db.Animals.Take(_count).ToList<IAnimal>();
                return animals;        
            }
        /*
            var fn = Path.GetFullPath(seedSource);
            var _seeder = new csSeedGenerator(fn);

            //var animal = new csAnimal().Seed(_seeder);

            // List<IAnimal> animals = new List<IAnimal>();
            // animals.Add(new csAnimal(){ Name = "AAAA"});
            // animals.Add(new csAnimal(){ Name = "BBBB"});

            var animals = _seeder.ItemsToList<csAnimal>(_count).ToList<IAnimal>();
            return animals;
        }
        */
    }
    public void Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            // List<csAnimal> animals = new List<csAnimal>();
            // animals.Add(new csAnimal(){ Name = "AAAA"});
            // animals.Add(new csAnimal(){ Name = "BBBB"});
            var animals = _seeder.ItemsToList<csAnimal>(_count);
            db.Animals.AddRange(animals);

            db.SaveChanges();

        }
    }
}