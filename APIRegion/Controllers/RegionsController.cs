using APIRegion.Models;
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
        public List<RegionModel> GetByName(string name)
        {
            var regions = bRegion.Get(new Region { RegionName= name });

            //Regiones de entidad => regions de Modelo
            var response = regions.Select(x => new RegionModel
            {
                Id = x.RegionId,
                Name = x.RegionName

            }).ToList();

            return response;
        }
    }
}
