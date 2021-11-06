using System.Collections.Generic;
using System.Threading.Tasks;
using TrackTileBackend.Models.TtnDevices;

namespace TrackTileBackend.IRepositories
{
    public interface ITtnDeviceRepository
    {
        Task Add(TtnData ttnData);
        IEnumerable<TtnData> GetAll();
        IEnumerable<TtnData> GetSome();
        TtnData GetDevice(int id);
    }
}
