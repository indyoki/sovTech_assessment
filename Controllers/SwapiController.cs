using ChuckSwapi.Components.Interfaces;
using ChuckSwapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ChuckSwapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SwapiController : ControllerBase
    {
        private readonly ILogger<SwapiController> _logger;
        private readonly ISWLogic _iswLogic;
        public SwapiController(ILogger<SwapiController> logger, ISWLogic iswLogic)
        {
            _iswLogic = iswLogic;
            _logger = logger;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("people")]
        public async Task<ActionResult<List<Person>>> GetAllPeople()
        {
            try
            {
                var result = await _iswLogic.GetAllEntries();
                if (result == null || !result.Any())
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while attempting to retrieve all SW people. Exception: @ex ", ex);
                throw;
            }
        }
    }
}
