using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhoShamBoAPI.Data;
using RhoShamBoAPI.Model;

namespace RhoShamBoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourneysController : ControllerBase
    {
        private readonly InterfaceRepository _repo; // _repo is a local var
        private readonly ILogger<TourneysController> _logger; //logging is for debugging purposes

        // Constructor
        public TourneysController(InterfaceRepository repo, ILogger<TourneysController> logger)
        {
            _repo = repo; //assign passed-in repo to local repo
            _logger = logger;
        }


        // Method

        //GET /api/tourneys
        [HttpGet] //this is a mapping for http for a get method, so now when this app receives a GET request, it is redirected here. [HttpGet] is dotnet specific
        public async Task<ActionResult<IEnumerable<Tourney>>> GetAllTourneys()
        {
            IEnumerable<Tourney> tourneys;

            try
            {
                tourneys = await _repo.GetAllTourneysAsync(); //for c# async methods, you have to use await, you cannot invoke async methods directly
            }

            catch (Exception e)
            {
                _logger.LogError(e, e.Message); //logging error
                return StatusCode(500); // return code sent back to requester - this is a bad response.
            }

            return tourneys.ToList();
        }
    }
}
