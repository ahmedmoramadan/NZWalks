namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> GetByIdAsync(Guid walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> UpdateAsync(Guid id ,Walk walk);
        Task<Walk?> DeleteAsync(Guid id); 
    }
    public class WalkRepository : IWalkRepository
    {
        private readonly AppDbContext _Context;
        public WalkRepository(AppDbContext context) 
        {
            _Context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _Context.AddAsync(walk);
            await _Context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
           var EWK = await GetByIdAsync(id);
            if (EWK == null) { return null; }
            _Context.Walks.Remove(EWK);
            await _Context.SaveChangesAsync();
            return EWK;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
           return await _Context.Walks.Include(x=>x.Region).Include(x=>x.Difficulty).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid walk)
        {
            var WK = await _Context.Walks.Include(x=>x.Difficulty).Include(x=>x.Region).FirstOrDefaultAsync(x => x.Id == walk);
            return WK;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var WalkDomain = await _Context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (WalkDomain == null) return null!;
            WalkDomain.Name = walk.Name;
            WalkDomain.Description = walk.Description;
            WalkDomain.LengthInKm = walk.LengthInKm;
            WalkDomain.WalkImageUrl = walk.WalkImageUrl;
            WalkDomain.DifficultyId = walk.DifficultyId;
            WalkDomain.RegionId = walk.RegionId;
            await _Context.SaveChangesAsync();
            return WalkDomain;
        }

        
    }
}
