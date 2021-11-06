using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TrackTileBackend.Hubs
{
    public class TtnData : Hub
    {
        public async Task TtnDataUpload(TtnData ttnData)
        {
            await Clients.All.SendAsync("TtnDataUpload", ttnData);

            //Send the data here
            //await _messagesRepository.AddMessage(ttnData);
        }
    }
}
