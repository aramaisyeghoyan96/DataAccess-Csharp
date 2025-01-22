using Configuration;
using DbModels;
using DbContext;
using Seido.Utilities.SeedGenerator;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Models.DTO;
namespace DbRepos;


public class csAttractionRepo : IAttractionRepo
{
    // Soruce path for seeding data
    const string _seedSource = "./friends-seeds1.json";
    
    // Method to seed the database with generated data
    public async Task RobustSeedAsync()
    {
        // Get the full path of the seed source file and Initialize seed generator with seed data file
        var fn = Path.GetFullPath(_seedSource);
        var _seeder = new csSeedGenerator(fn);

        // Open a new database context
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            // Generate a list of 50 users and 1000 attractions
            var users = _seeder.ItemsToList<csUserDbM>(50);
            var attractions = _seeder.ItemsToList<csAttractionDbM>(1000);

            // Initialize lists for comments and locations
            var allComments = new List<csCommentDbM>();
            var locations = new List<csLocationDbM>(100);


            // Loop through each attraction
            foreach (var attraction in attractions)
            {
                // Generate a new location for each attraction
                var newLocation = new csLocationDbM().Seed(_seeder);

                // Check if the location already exists in the local list or in the database
                var exsistLocation = locations.FirstOrDefault(l => l.Country == newLocation.Country && l.City == newLocation.City)
                ?? db.Locations.FirstOrDefault(l => l.Country == newLocation.Country && l.City == newLocation.City);


                 // If location doesn't exist, add it to the local list, otherwise reuse the existing location
                if (exsistLocation == null)
                {
                    locations.Add(newLocation);
                    attraction.LocationDbM = newLocation;
                }
                else
                {
                    attraction.LocationDbM = exsistLocation;
                }

                // Generate a random number of comments for each attraction (0-20 comments)
                int nmrOfComments = _seeder.Next(0, 21);
                if (nmrOfComments > 0)
                {
                    // Loop to create comments for the attraction
                    for (int i = 0; i < nmrOfComments; i++)
                    {
                        var comment = new csCommentDbM().Seed(_seeder);
                        comment.UserDbM = _seeder.FromList(users); // Assign a random user to the comment
                        comment.AttractionDbM = attraction; // Associate comment with the attraction

                        allComments.Add(comment);
                    }

                }

            }
            // Add users, attractions, and comments to the database
            db.Users.AddRange(users);
            db.Attractions.AddRange(attractions);
            db.Comments.AddRange(allComments);

            await db.SaveChangesAsync();
        }
    }

    // Method to delete seeded data
    public async Task DeleteRobustSeedAsync()
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            // Remove comments, attractions, locations, and users in that order
            
            db.Comments.RemoveRange(db.Comments); // Delete comments first
            db.Attractions.RemoveRange(db.Attractions); // Then attractions
            db.Locations.RemoveRange(db.Locations); // Then locations
            db.Users.RemoveRange(db.Users); // Finally, users

            await db.SaveChangesAsync();

        }

    }

    // Method to read and return paginated attractions based on filters
    public async Task<csRespPageDTO<IAttraction>> ReadAttractionsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            IQueryable<csAttractionDbM> _query;
            
            // Check if flat (without relationships) or include related data
            if (flat)
            {
                _query = db.Attractions.AsNoTracking();
            }
            else
            {
                _query = db.Attractions.AsNoTracking()
                    .Include(i => i.LocationDbM)
                    .Include(i => i.CommentDbM);




            }

            // Filtering by category, title, description, country, and city
            if (!string.IsNullOrEmpty(filter))
            {
                _query = _query.Where(a =>
                 (a.Category != null && a.Category.Contains(filter)) ||
                 (a.Title != null && a.Title.Contains(filter)) ||
                 (a.Description != null && a.Description.Contains(filter)) ||
                 (a.LocationDbM != null && a.LocationDbM.Country != null && a.LocationDbM.Country.Contains(filter)) ||
                 (a.LocationDbM != null && a.LocationDbM.City != null && a.LocationDbM.City.Contains(filter))
                 );
            }



            // Pagination (skip and take)
            var totalItems = await _query.CountAsync();
            var items = await _query
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync<IAttraction>();

            // Returning paginated response
            var _ret = new csRespPageDTO<IAttraction>
            {
                PageItems = items,
                DbItemsCount = totalItems,
                PageNr = pageNumber,
                PageSize = pageSize
            };

            return _ret;
        }
    }

    // Method to read and return paginated attractions without comments
    public async Task<csRespPageDTO<IAttraction>> ReadAttractionsWithoutCommentsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            IQueryable<csAttractionDbM> _query;

            // Query for attractions that have no comments
            if (flat)
            {
                _query = db.Attractions
                    .Where(a => !a.CommentDbM.Any()) // Filter for attractions without comments
                    .AsNoTracking();
            }
            else
            {
                _query = db.Attractions
                    .Include(i => i.LocationDbM) // include location
                    .Where(a => !a.CommentDbM.Any())
                    .AsNoTracking();
            }

            // Apply filter on category, title, description, country, or city
            if (!string.IsNullOrEmpty(filter))
            {
                _query = _query.Where(a =>
                    (a.Category != null && a.Category.Contains(filter)) ||
                    (a.Title != null && a.Title.Contains(filter)) ||
                    (a.Description != null && a.Description.Contains(filter)) ||
                    (a.LocationDbM != null && a.LocationDbM.Country != null && a.LocationDbM.Country.Contains(filter)) ||
                    (a.LocationDbM != null && a.LocationDbM.City != null && a.LocationDbM.City.Contains(filter))
                );
            }

            // Validate pagenumber ensure its atleast 1
            if (pageNumber < 1) // Om pageNumber är mindre än 1, sätt det till 1
            {
                pageNumber = 1;
            }

            var totalItems = await _query.CountAsync();  // Get total count of filtered items
            var items = await _query
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize)  // Take only the required number of items
                .ToListAsync<IAttraction>();

            // Return paginated response
            var _ret = new csRespPageDTO<IAttraction>
            {
                PageItems = items,
                DbItemsCount = totalItems,
                PageNr = pageNumber,
                PageSize = pageSize
            };

            return _ret;
        }
    }

    // Method to read a single attraction by its ID
    public async Task<csAttractionDbM> ReadSingleAttractionAsync(Guid attractionId)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            // Retrieve attraction with related comments and location
            var attraction = await db.Attractions
                .AsNoTracking()
                .Include(a => a.CommentDbM)
                .Include(a => a.LocationDbM)
                .Where(a => a.AttractionId == attractionId)
                .FirstOrDefaultAsync();

            // Return the attraction, or null if not found
            if (attraction == null)
            {
                return null;
            }

            return attraction;
        }
    }
    
    // Method to read and return paginated users based on filters
    public async Task<csRespPageDTO<IUser>>ReadUsersAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize)
    {
        using (var db = csMainDbContext.DbContext("sysadmin"))
        {
            IQueryable<csUserDbM> _query;

            // Check if flat (without relationships) or include related data (Comments)
            if (flat)
            {
                _query = db.Users.AsNoTracking();
            }
            else
            {
                _query = db.Users.AsNoTracking()
                    .Include(i => i.CommentsDbM);
            }

            // Apply filter on user name
            if (!string.IsNullOrEmpty(filter))
            {
                _query = _query.Where(a =>
                    a.Name != null && a.Name.Contains(filter)
                    
                );
            }



            // Pagination (skip and take)
            var totalItems = await _query.CountAsync();
            var items = await _query
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync<IUser>();

            // Returning paginated response
            var _ret = new csRespPageDTO<IUser>
            {
                PageItems = items,
                DbItemsCount = totalItems,
                PageNr = pageNumber,
                PageSize = pageSize
            };

            return _ret;
        }
    }


}