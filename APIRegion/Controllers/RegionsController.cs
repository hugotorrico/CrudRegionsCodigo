using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRegion.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        BRegion bRegion = new BRegion();

        [HttpGet]
        public List<Region> GetByName(string name)
        {
            var response = bRegion.Get(new Region { RegionName= name });
            return response;
        }
    }
}
