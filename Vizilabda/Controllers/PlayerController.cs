using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizilabda.Models;

namespace Vizilabda.Controllers
{
    [Route("Players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Player> Post(CreatePlayerDto createplayer)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Name = createplayer.Name,
                Age = createplayer.Age,
                Height = createplayer.Height,
                Weight = createplayer.Weight,
                CreatedTime = DateTime.Now
            };
            if (player != null)
            {
                using (var context = new OlimpiaContext())
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                }
            }
            return BadRequest();
        }
        [HttpGet]
        public ActionResult<Player> Get() {
            using (var context = new OlimpiaContext())
            {
                return Ok(context.Players.ToList());
            }

        }
    
    }
}
