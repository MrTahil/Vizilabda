using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("{id}")]
        public ActionResult<Data> GetById(Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == id);
                if (player != null)
                {
                    return Ok(player);
                }
                return NotFound();

            }
        }
        [HttpPut("({id})")]
        public ActionResult<Player> Put(UpdatePlayerDto update, Guid id)
        {
            using (var context = new OlimpiaContext())
            {
                var explay = context.Players.FirstOrDefault(x => x.Id == id);
                if (explay != null) { explay.Name = update.Name;
                explay.Weight = update.Weight;
                    explay.Age = update.Age;
                    explay.Height = update.Height;
                    context.Players.Update(explay);
                    context.SaveChanges();
                    return Ok(explay);
                }
                return NotFound();
            } }
        [HttpGet("playerData/{id}")]
        public ActionResult<Player> Get(Guid id) {
            using (var context = new OlimpiaContext())
            {
                var player = context.Players.Include(x => x.Data).FirstOrDefault(player => player.Id == id);
                if (player != null) { return Ok(player); }
                return NotFound();
            }
            }
    }
}
