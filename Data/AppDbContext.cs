using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOption) : base(dbContextOption)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("64933176-8469-48f2-a7c6-1eef0aba09c4"),
                    Name = "Easy"

                },
                     new Difficulty()
                {
                    Id= Guid.Parse("d7cf3178-e752-495c-b3e4-0fbfa11462fc"),
                    Name = "Medium"
                },
                      new Difficulty()
                {
                    Id= Guid.Parse("74fc6221-ec69-48a2-b0d9-7c1c71b8451a"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("2aa48e14-449e-4c3d-93d7-573bc83565e9"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.aucklandnz.com/sites/build_auckland/files/styles/scale_and_crop_1440x900_/public/media-library/images/Explore%20more/Te%20Puia%20Rotorua%20Hot%20Pools%20%26%20Geysers.jpg"
                },

                new Region
                {
                    Id = Guid.Parse("b5d76e1e-8d45-4d2a-8d95-cf530f3a40c3"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = null
                },

                new Region
                {
                    Id = Guid.Parse("d9d3d8e4-b91d-4c6e-9c2d-3f0a41cb8c85"),
                    Name = "Christchurch",
                    Code = "CHC",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/67/Christchurch_%28NZ%29_-_flickr_-_spsmith.jpg"
                },

                new Region
                {
                    Id = Guid.Parse("a3d3c8f6-c2a1-4a1b-bb1e-8f4e43efc9d2"),
                    Name = "Dunedin",
                    Code = "DUD",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f2/Dunedin_New_Zealand_01.jpg"
                }
            };
            modelBuilder.Entity<Region>().HasData(regions); 
        }

    }
}
