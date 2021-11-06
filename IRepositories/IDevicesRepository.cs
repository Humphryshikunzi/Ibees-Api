using System.Collections.Generic;
using System.Threading.Tasks;
using TrackTileBackend.Models;
using TrackTileBackend.Models.SigfoxDevices;

namespace TrackTileBackend.IRepositories
{
    public interface IDevicesRepository
    {
        Task SaveDeviceData(TttnTestData tttnTestData);
        IEnumerable<TttnTestData> GetDevices();
        TttnTestData GetDevice(int id);
        Task DeleteDevice(int id);
        Task UpDateDevice(TttnTestData help);


        //For Sigfox
        Task AddSigfoxDevice(SigfoxDevice sigfoxDevice);
        IEnumerable<SigfoxDevice> GetSigfoxDevices();
        IEnumerable<SigfoxDevice> GetSomeSigfoxDevicesData(int from, int to);
        IEnumerable<SigfoxDevice> GetLastElements(int totalNo);
    }
}
