using Models;
using DbModels;
using Models.DTO;
namespace DbRepos;

public interface IAttractionRepo
{
     public Task RobustSeedAsync();
     public Task DeleteRobustSeedAsync();

     public Task<csRespPageDTO<IAttraction>> ReadAttractionsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

     public  Task<csRespPageDTO<IAttraction>> ReadAttractionsWithoutCommentsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

     public  Task<csAttractionDbM> ReadSingleAttractionAsync(Guid attractionId);

     public  Task<csRespPageDTO<IUser>> ReadUsersAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

}