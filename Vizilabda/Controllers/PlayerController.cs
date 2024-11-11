using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizilabda.Models;

namespace Vizilabda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public ActionResult<Player> Post(CreatePlayerDto createplayer)
        {
            var player = new Player
            {
                Id=Guid.NewGuid(),
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
    }
}
