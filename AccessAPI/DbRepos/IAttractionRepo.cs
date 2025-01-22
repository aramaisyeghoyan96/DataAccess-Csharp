using Models;
using DbModels;
namespace DbRepos;

public interface IAttractionRepo
{
    public Task<List<IAttraction>> Attractions (int _count);
    public Task Seed(int _count);
}