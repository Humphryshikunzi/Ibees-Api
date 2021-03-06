using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackTileBackend.Models;
using TrackTileBackend.Models.SigfoxDevices;
using TrackTileBackend.Models.TtnDevices;

namespace TrackTileBackend
{
    public class IbeesDbContext : IdentityDbContext<AppUser>
    {
        public IbeesDbContext(DbContextOptions<IbeesDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }  
          
        public  DbSet<AppUser>  AppUsers { get; set; }
        public  DbSet<TttnTestData> TttnTestData { get; set; }
        public  DbSet<TtnData> TtnData { get; set; }
        public  DbSet<SigfoxDevice> SigfoxDevices { get; set; }
    }
}
