using Models;
using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.DTO;
using DbModels;



namespace Services;

public interface IAttractionService
{
    Task RobustSeedAsync();
    
    Task DeleteRobustSeedAsync();

    Task<csRespPageDTO<IAttraction>> ReadAttractionsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

    // Task<csRespPageDTO<IAttraction>> ReadAttractionsWithoutCommentsAsync(int pageNumber, int pageSize);

    Task<csRespPageDTO<IAttraction>> ReadAttractionsWithoutCommentsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

    Task<csAttractionDbM> ReadSingleAttractionAsync(Guid attractionId);

    Task<csRespPageDTO<IUser>> ReadUsersAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

}