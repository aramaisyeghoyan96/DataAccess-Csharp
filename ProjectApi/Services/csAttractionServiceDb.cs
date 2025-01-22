using Configuration;
using Models;
using DbRepos;
using Models.DTO;
using DbModels;



using Seido.Utilities.SeedGenerator;

namespace Services;


public class csAttractionServiceDb: IAttractionService 
{

    private IAttractionRepo _repo = null;

    public async Task RobustSeedAsync() // Ändrad till Task för asynkronitet
    {
        await _repo.RobustSeedAsync(); // Använd await för att säkerställa att anropet fullföljs
    }

    public async Task DeleteRobustSeedAsync ()
    {
        await _repo.DeleteRobustSeedAsync();
    }

    public async Task<csRespPageDTO<IAttraction>> ReadAttractionsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
       =>   await _repo.ReadAttractionsAsync(seeded, flat, filter, pageNumber, pageSize );
    
    public async Task<csRespPageDTO<IAttraction>> ReadAttractionsWithoutCommentsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
            => await _repo.ReadAttractionsWithoutCommentsAsync(seeded, flat, filter, pageNumber, pageSize);
    
    public async Task<csAttractionDbM> ReadSingleAttractionAsync (Guid attractionId)
            => await _repo.ReadSingleAttractionAsync(attractionId);

    public async Task<csRespPageDTO<IUser>> ReadUsersAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
            => await _repo.ReadUsersAsync(seeded, flat, filter, pageNumber, pageSize);   



    
            
            
    

   

    public csAttractionServiceDb(IAttractionRepo repo)
    {
        _repo = repo;
    }
}