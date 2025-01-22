using Configuration;
using Models;
using DbRepos;


using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAttractionServiceDb: IAttractionService {

    private IAttractionRepo _repo = null;


    
    public async Task<List<IAttraction>> Attractions(int _count) => await _repo.Attractions(_count);
    public async Task Seed(int _count) => await _repo.Seed(_count);

   

    public csAttractionServiceDb(IAttractionRepo repo)
    {
        _repo = repo;
    }
}