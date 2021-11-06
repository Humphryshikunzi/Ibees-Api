using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackTileBackend.IRepositories;
using TrackTileBackend.Models;
using TrackTileBackend.Models.SigfoxDevices;
using TrackTileBackend.Services;

namespace TrackTileBackend.Repositories
{
    public class DevicesRepository : IDevicesRepository
    {
        private readonly IbeesDbContext _dbContext;
        public DevicesRepository(IbeesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveDeviceData(TttnTestData tttnTestData)
        {
            EmailServices.MailTestForTTN(tttnTestData);
            _dbContext.TttnTestData.Add(tttnTestData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDevice(int id)
        {
            _dbContext.TttnTestData.Remove(_dbContext.TttnTestData.Find(id));
            await _dbContext.SaveChangesAsync();
        }

        public TttnTestData GetDevice(int id)
        {
            return _dbContext.TttnTestData.Where(h => h.Id == id).FirstOrDefault();
        }

        public IEnumerable<TttnTestData> GetDevices()
        {
            return _dbContext.TttnTestData;
        }

        public async Task UpDateDevice(TttnTestData tttnTestData)
        {
            _dbContext.TttnTestData.Update(tttnTestData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddSigfoxDevice(SigfoxDevice sigfoxDevice)
        {
             //EmailServices.MailTestForSigfox(sigfoxDevice);
            _dbContext.SigfoxDevices.Add(sigfoxDevice);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<SigfoxDevice> GetSigfoxDevices()
        {
           return  _dbContext.SigfoxDevices;
        }

        public IEnumerable<SigfoxDevice> GetSomeSigfoxDevicesData(int from, int to)
        {
            return _dbContext.SigfoxDevices.Where(d => d.Id >= from).Where(d => d.Id <= to).ToList();
        }

        public IEnumerable<SigfoxDevice> GetLastElements(int totalNo)
        {
            var allElements = _dbContext.SigfoxDevices;
            var indexFrom = allElements.ToList().Count - totalNo;
            return allElements.ToList().Where(e => e.Id >= indexFrom);
        }
    }
}
