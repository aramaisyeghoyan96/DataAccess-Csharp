using Models;
using Seido.Utilities.SeedGenerator;

namespace Services;

public interface IAttractionService
{
    public Task<List<IAttraction>> Attractions (int _count);
    public Task Seed(int _count);
}