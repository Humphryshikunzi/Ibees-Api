using ALoRa.Library;
using System;
using System.Threading;

namespace TrackTileBackend.Services.TtnService
{
    public class GetTtnData
    {
        public static void GetDevicesData()
        {
            var appId = "maker-session";
            var accessKey = "ttn-account-v2.ymC4-oojWZMYdAKJfmjTk-SL8OdZuvenjgpaJvP5yFo";
            var gateWayId = "iot-mashinani";

            Console.WriteLine("Attempting to connect to the Things Network");

            var app = new TTNApplication(appId, accessKey, "eu");
            app.MessageReceived += App_MessageReceived;

            Console.WriteLine("Press return to exit!");
            Console.ReadLine();
            app.Dispose();
            Thread.Sleep(1000);

        }

        private static void App_MessageReceived(TTNMessage obj)
        {
            var data = BitConverter.ToString(obj.Payload);
            var payload = obj.Payload;
            string stringData = obj.Payload.ToString();

            Console.WriteLine($"Message timestamp : {obj.Timestamp}\n" +
                              $"Device            : {obj.DeviceID}\n" +
                              $"Topic             : {obj.Topic}\n" +
                              $"Data              : {data}\n" +
                              $"All               : {obj}\n" +
                              $"Payload           : {payload}" +
                              $"string data       : {stringData}");
            
        }
    }
}
