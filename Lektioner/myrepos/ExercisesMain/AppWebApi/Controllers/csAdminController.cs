using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Seido.Utilities.SeedGenerator;

using Models;
using Services;
using Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csAdminController : Controller
    {
        private ILogger<csAdminController> _logger = null;

        private IAnimalsService _service = null;

        //GET: api/csAdmin/Info
        [HttpGet()]
        [ActionName("Info")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Info()
        {
            try
            {
                _logger.LogInformation("Endpoint Info executed");
                return Ok(csAppConfig.SecretSource);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/AfricanAnimals
        [HttpGet()]
        [ActionName("AfricanAnimals")]
        [ProducesResponseType(200, Type = typeof(List<csAnimal>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> AfricanAnimals(string count)
        {
            try
            {
                _logger.LogInformation("Endpoint AfricanAnimals executed");
                int _count = int.Parse(count);


                List<IAnimal> animals = _service.AfricanAnimals(_count);
                //List<IAnimal> animals = new csAnimalsService1().AfricanAnimals(_count);


                return Ok(animals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/AfricanAnimals
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string count)
        {
            try
            {
                _logger.LogInformation("Endpoint Seed executed");
                int _count = int.Parse(count);


                _service.Seed(_count);


                return Ok("Seeded");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/AfricanAnimals
        [HttpGet()]
        [ActionName("Singleton")]
        [ProducesResponseType(200, Type = typeof(csSingleton))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Singleton()
        {
            try
            {
                _logger.LogInformation("Endpoint Singleton executed");
                var si = csSingleton.Instance;

                return Ok(si);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/log
        [HttpGet()]
        [ActionName("Log")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csLogMessage>))]
        public async Task<IActionResult> Log([FromServices] ILoggerProvider _loggerProvider)
        {
            //Note the way to get the LoggerProvider, not the logger from Services via DI
            if (_loggerProvider is csInMemoryLoggerProvider cl)
            {
                return Ok(await cl.MessagesAsync);
            }
            return Ok("No messages in log");
        }
        public csAdminController(IAnimalsService service,  ILogger<csAdminController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}

