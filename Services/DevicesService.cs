using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using TrackTileBackend.Constants;
using TrackTileBackend.Models;

namespace TrackTileBackend.Services
{
    public static class DevicesService
    {
        public async static void GetDevicesData()
        {
            string latestDateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ");
            string previousDateTime = DateTime.Now.AddMinutes(-15).ToString("yyyy-MM-ddThh:mm:ssZ");
                  
            var tokenUri = "auth/token";
            var dataUri = $"sensors_data?device_id=Tracktile123&sensor_id=TC,HUM&date_from={previousDateTime}&date_to={latestDateTime}";
                   
            var authDto = new TrackTileAuth()
            {
                username = "Tracktile20@gmail.com",
                password = "TRACKTILE20"
            };

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(AppConstants.WaziHubBaseUri);
            var authDtoJson = JsonConvert.SerializeObject(authDto);
            var httpContent = new  StringContent(authDtoJson);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var authTokenResponse = await httpClient.PostAsync(tokenUri, httpContent);
            var authToken = authTokenResponse.Content.ReadAsStringAsync().Result;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            var serverResponse = await httpClient.GetAsync(dataUri);
            var trackTileData = JsonConvert.DeserializeObject<List<TrackTileDevice>>(serverResponse.Content.ReadAsStringAsync().Result);
            
            // take all sensors with same device Id, form a device and send this data to azure
            //

            // send this data to by trusted Azure
            // send the data to SignalR Hub, which will publish to the mobile phones
        
        }
    }
}
