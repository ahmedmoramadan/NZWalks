namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mapper , IWalkRepository walkRepository) 
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var WKD = await _walkRepository.GetByIdAsync(id);
            if (WKD == null) { return NotFound(); }
            return Ok(_mapper.Map<WalkDto>(WKD));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var WalkDomain = await _walkRepository.GetAllAsync();


            return Ok(_mapper.Map<List<WalkDto>>(WalkDomain));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkDto addWalksDto)
        {
            var WalkDomin = _mapper.Map<Walk>(addWalksDto);
            var W = await _walkRepository.CreateAsync(WalkDomin);
            
            return Ok(_mapper.Map<WalkDto>(W));
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalksDto UpdateWalksDto)
        {
            var Domain = _mapper.Map<Walk>(UpdateWalksDto);
            Domain = await _walkRepository.UpdateAsync(id, Domain);
            if(Domain == null) { return NotFound(); }
            return Ok(_mapper.Map<WalkDto>(Domain));
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var WK =await _walkRepository.DeleteAsync(id);
            if(WK == null) { return NotFound(); }
            return Ok(_mapper.Map<WalkDto>(WK));
        }
    }
}
