using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;


public interface IAnimalsService {

    public List<IAnimal> AfricanAnimals(int _count);
    public void Seed(int _count);
}
