using Configuration;
using Models;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;

namespace DbRepos;

public class csAttractionRepo : IAttractionRepo
{

    private const string seedSource = "./friends-seeds1.json";

    public async Task<List<csAttraction>> GetAttractions(int _count)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
                     return await db.Attractions.
                     Include(a => a.Comments) // Inkludera kommentarer om det är relevant
                    .Include(a => a.Location) // Inkludera platsinformation om det är relevant
                    .Take(_count)
                    .ToListAsync();
            

        }
    }
    public async Task Seed(int _count)
    {
        var fn = Path.GetFullPath(seedSource);
        var _seeder = new csSeedGenerator(fn);
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            var zoos = _seeder.ItemsToList<csZooDbM>(5);
            var animals = _seeder.ItemsToList<csAnimalDbM>(_count);

            foreach (var a in animals)
            {
                a.ZooDbM = _seeder.FromList(zoos);
            }
            
            
            db.Animals.AddRange(animals);
            await db.SaveChangesAsync();
        }
    }
}