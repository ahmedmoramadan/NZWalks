namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository , IMapper mapper)
        {
            _regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Region> RG = await _regionRepository.GetAllAsync();
            var RGDto = mapper.Map<List<RegionDto>>(RG);
            return Ok(RGDto);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var RG =await _regionRepository.GetByIdAsync(id);
            if(RG == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RegionDto>(RG));
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRegionDto AddR)
        {
            var RDM = mapper.Map<Region>(AddR);

            RDM = await _regionRepository.CreateAsync(RDM);
            var rgdto = mapper.Map<RegionDto>(RDM);
            return CreatedAtAction(nameof(GetById), new {id = rgdto.Id} , rgdto);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionDto Update)
        {
         
            var RGDto = mapper.Map<Region>(Update);

            RGDto = await _regionRepository.UpdateAsync(id, RGDto);
            if (RGDto == null) { return NotFound(); }
            var RMDto = mapper.Map<RegionDto>(RGDto);
            return Ok(RMDto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var RG = await _regionRepository.DeleteAsync(id);
            if(RG == null) { return NotFound(); }

            var RGDto = mapper.Map<RegionDto>(RG);
            return Ok(RGDto);
        }
    }
}
