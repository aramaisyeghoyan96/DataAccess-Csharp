using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

using Models;
using Services;
using Configuration;
using DbRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{


    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csProjectController : Controller
    {

        private ILogger<csProjectController> _logger = null;
        IAttractionService _service = null;
        // private ILogger<csAdminController> _logger = null;

        //GET: api/Attractions/Read
        [HttpGet()]
        [ActionName("ReadAttractions")]
        [ProducesResponseType(200, Type = typeof(csRespPageDTO<IAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ReadAttractions(string seeded = "true", string flat = "true",
            string filter = null, string pageNr = "0", string pageSize = "10")
        {
            _logger.LogInformation("Endpoint Attractions executed");
            try
            {
                _logger.LogInformation("Endpoint Attractions executed");
                bool _seeded = bool.Parse(seeded);
                bool _flat = bool.Parse(flat);
                int _pageNr = int.Parse(pageNr);
                int _pageSize = int.Parse(pageSize);

                var _resp = await _service.ReadAttractionsAsync(_seeded, _flat, filter?.Trim()?.ToLower(), _pageNr, _pageSize);
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GET: api/Attractions/ReadWithoutComments
        [HttpGet()]
        [ActionName("ReadAttractionsWithoutComment")]
        [ProducesResponseType(200, Type = typeof(csRespPageDTO<IAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ReadWithoutComments(string seeded = "true", string flat = "true",
            string filter = null, string pageNr = "0", string pageSize = "10")
        {
            _logger.LogInformation("Endpoint Attractions executed");
            try
            {
                _logger.LogInformation("Endpoint Attractions executed");
                bool _seeded = bool.Parse(seeded);
                bool _flat = bool.Parse(flat);
                int _pageNr = int.Parse(pageNr);
                int _pageSize = int.Parse(pageSize);

                var _resp = await _service.ReadAttractionsWithoutCommentsAsync(_seeded, _flat, filter?.Trim()?.ToLower(), _pageNr, _pageSize);
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/Attractions/GetAttractionById/{attractionId}
        [HttpGet()]
        [ActionName("GetAttractionById")]
        [ProducesResponseType(200, Type = typeof(IAttraction))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> GetAttractionById(Guid attractionId)
        {
            _logger.LogInformation($"Endpoint GetAttractionById executed for AttractionId: {attractionId}");

            try
            {
                var attraction = await _service.ReadSingleAttractionAsync(attractionId);

                if (attraction == null)
                {
                    _logger.LogWarning($"Attraction with ID {attractionId} not found.");
                    return NotFound("Attraction not found.");
                }

                return Ok(attraction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the attraction with ID {attractionId}");
                return BadRequest(ex.Message);
            }
        }


        // GET: api/User/ReadUsers
        [HttpGet]
        [ActionName("ReadUsers")]
        [ProducesResponseType(200, Type = typeof(csRespPageDTO<IUser>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> ReadUsers(bool seeded = true, bool flat = true, 
            string filter = null, string pageNr = "0", string pageSize = "10")
        {
            _logger.LogInformation("Endpoint ReadUsers executed");
            try
            {
                bool _seeded = seeded;
                bool _flat = flat;
                int _pageNr = int.Parse(pageNr);
                int _pageSize = int.Parse(pageSize);

                var _resp = await _service.ReadUsersAsync(_seeded, _flat, filter?.Trim()?.ToLower(), _pageNr, _pageSize);
                return Ok(_resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching users");
                return BadRequest(ex.Message);
            }
        }

        




        public csProjectController(IAttractionService service, ILogger<csProjectController> logger)
        {
            _service = service;
            _logger = logger;
        }



    }
}

