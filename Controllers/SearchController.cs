using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChuckSwapi.Components.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ChuckSwapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IChuckLogic _chuckLogic;
        private readonly ISWLogic _swLogic;

        public SearchController(ILogger<SearchController> logger, IChuckLogic chuckLogic, ISWLogic swLogic)
        {
            _logger = logger;
            _chuckLogic = chuckLogic;
            _swLogic = swLogic;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{query}")]
        public async Task<ActionResult> Get(string query)
        {
            try
            {
                var swp = await _swLogic.Search(query);
                if (swp != null)
                {
                    HttpContext.Response.Headers.Add("queried-api", "SWApi");
                    return Ok(swp);
                }

                var chuckJoke = await _chuckLogic.Search(query);
                if (!string.IsNullOrEmpty(chuckJoke))
                {
                    HttpContext.Response.Headers.Add("queried-api", "ChuckApi");
                    return Ok(chuckJoke);
                }

                return NotFound($"No results found for the search term {query}");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while attempting to retrieve joke categories. Exception: @ex ", ex);
                throw;
            }
        }
    }
}
