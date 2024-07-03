using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Create(AddRegionDto AddR)
        {
            var RG = new Region
            {
                Code = AddR.Code,
                Name = AddR.Name,
                RegionImageUrl = AddR.RegionImageUrl,
            };

            var rgdto = new RegionDto
            {
                Id = RG.Id,
                Name = RG.Name,
                RegionImageUrl = RG.RegionImageUrl,
            };
            return CreatedAtAction(nameof(GetById), new {id = RG.Id} , rgdto);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute]Guid id, [FromBody] UpdateRegionDto Update)
        {

            return Ok();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            return Ok();
        }
    }
}
