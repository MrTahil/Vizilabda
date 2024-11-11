using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vizilabda.Models;

namespace Vizilabda.Controllers
{
    [Route("Data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Data> Post(CreateDataDto createDto)
        {
            var data = new Data
            {
                Id = Guid.NewGuid(),
                Country = createDto.Country,
                County = createDto.County,
                Description = createDto.Description,
                UpdatedTime = DateTime.Now,
                CreatedTime = DateTime.Now,
                PlayerId = createDto.Id
            };
            if (data != null)
            {
                using (var context = new OlimpiaContext())
                {
                    context.Datas.Add(data);
                    context.SaveChanges();
                    return StatusCode(201, data);
                }
            }
            return BadRequest();
        }
        }
}
