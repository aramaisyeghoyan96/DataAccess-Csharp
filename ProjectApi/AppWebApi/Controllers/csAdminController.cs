using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models;
using Services;
using Configuration;
using DbRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csAdminController : Controller
    {
        // private ILogger<csAdminController> _logger = null;

        IAttractionService _iAttractionService = null;
        
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> RobustSeedAsync()
        {
            try
            {
               await _iAttractionService.RobustSeedAsync();
                return Ok("Sedeed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [ActionName("RemoveSeed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> DeleteRobustSeedAsync()
        {
            try
            {
               await _iAttractionService.DeleteRobustSeedAsync();
                return Ok("Seed removed from database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public csAdminController(IAttractionService service)
        {
            _iAttractionService = service;

        }
        
       
    }
}

