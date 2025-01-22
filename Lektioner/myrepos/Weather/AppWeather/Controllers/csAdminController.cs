using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Configuration;
using Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeather.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csAdminController : Controller
    {
        //GET: api/musicgroups/seed?count={count}
        [HttpGet()]
        [ActionName("Info")]
        [ProducesResponseType(200, Type = typeof(csConfAdress))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Info()
        {
            try
            {
                return Ok(csAppConfig.Address);
                 
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}

