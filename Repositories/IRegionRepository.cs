namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(); 
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region>  CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id , Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;
        public RegionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _context.AddAsync(region);
           await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
           var RG = await GetByIdAsync(id);
            if (RG == null) { return null!; }
             _context.Regions.Remove(RG);
            await _context.SaveChangesAsync();
            return RG;
        }

        public async Task<List<Region>> GetAllAsync()=>await _context.Regions.ToListAsync();

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           var RG =await _context.Regions.FindAsync(id);
            if (RG == null) return null!;
            return RG;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var RG =await GetByIdAsync(id);
            if (RG == null) return null!;
           RG.Code = region.Code;
            RG.Name = region.Name;
            RG.RegionImageUrl = region.RegionImageUrl;
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
