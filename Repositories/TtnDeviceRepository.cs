using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackTileBackend.IRepositories;
using TrackTileBackend.Models.TtnDevices;

namespace TrackTileBackend.Repositories
{
    public class TtnDeviceRepository : ITtnDeviceRepository
    {
        private readonly IbeesDbContext _trackTileDbContext;

        public TtnDeviceRepository(IbeesDbContext trackTileDbContext)
        {
            this._trackTileDbContext = trackTileDbContext;
        }
        public async Task Add(TtnData ttnData)
        {
            _trackTileDbContext.TtnData.Add(ttnData);
            await _trackTileDbContext.SaveChangesAsync(); ;
        }

        public IEnumerable<TtnData> GetAll()
        {
            return _trackTileDbContext.TtnData.Include(f => f.Fields).Include(t => t.Tags);
        }

        public TtnData GetDevice(int id)
        {
            return _trackTileDbContext.TtnData.Where(h => h.Id == id).FirstOrDefault();
        }

        public IEnumerable<TtnData> GetSome()
        {
            // will use time to filter previously updated values
            return _trackTileDbContext.TtnData;
        }
    }
}
