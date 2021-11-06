using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using TrackTileBackend.Services;
using TrackTileBackend.Services.TtnService;

namespace TrackTileBackend
{
    public class Program
    {
        private static void ThreadProc()
        {
            while (true)
            {
                Console.WriteLine("Hey Africa");
                Thread.Sleep(1000*60*15);
                DevicesService.GetDevicesData();
            }
        }
        private static void TtnListener()
        {
            GetTtnData.GetDevicesData();
        }

        public static void Main(string[] args)
        {               
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();

            Thread ttnListner = new Thread(new ThreadStart(GetTtnData.GetDevicesData));
            ttnListner.Start();

            CreateHostBuilder(args).Build().Run();
           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
