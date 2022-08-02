using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhoShamBoAPI.Data;
using RhoShamBoAPI.Model;

namespace RhoShamBoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        // Fields
        //creating ways so that the controller can connect to the DB
        private readonly InterfaceRepository _repo; // _repo is a local var
        private readonly ILogger<PlayersController> _logger; //logging is for debugging purposes

        // Constructor
        public PlayersController(InterfaceRepository repo, ILogger<PlayersController> logger)
        {
            _repo = repo; //assign passed-in repo to local repo
            _logger = logger;
        }


        // Method

        //GET /api/players
        [HttpGet] //this is a mapping for http for a get method, so now when this app receives a GET request, it is redirected here. [HttpGet] is dotnet specific
        public async Task<ActionResult<IEnumerable <Player>>> GetAllPlayers()
        {
            IEnumerable<Player> players;

            //safer implementation than IEnumerable<Player> players = await _repo.GetAllPlayersAsync()
            try
            {
                players = await _repo.GetAllPlayersAsync(); //for c# async methods, you have to use await, you cannot invoke async methods directly
            }

            catch (Exception e)
            {
                _logger.LogError(e, e.Message); //logging error
                return StatusCode(500); // return code sent back to requester - this is a bad response.
            }

            return players.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer([FromBody]Player player)
        {
            _logger.LogInformation("Player Name = " + player.Name);
            try
            {
                if (player == null)
                    return StatusCode(500);
                var createdPlayer = await _repo.InsertPlayerAsync(player.Name, player.City, player.Email);

                return player;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message); //logging error
                return StatusCode(500); // return code sent back to requester - this is a bad response.
            }
                    
        }
        

        
        //public async Task<ActionResult<IEnumerable<Player>>> InsertPlayer(string name, string City, string email )
        //{
        //    IEnumerable<Player> players;

        //    //safer implementation than IEnumerable<Player> players = await _repo.GetAllPlayersAsync()
        //    try

        //    {
        //        players = await _repo.GetAllPlayersAsync(); //for c# async methods, you have to use await, you cannot invoke async methods directly
        //    }

        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, e.Message); //logging error
        //        return StatusCode(500); // return code sent back to requester - this is a bad response.
        //    }

        //    return players.ToList();
        //}

    }
}
