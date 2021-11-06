namespace TrackTileBackend.Models.TtnDevices
{
    public class Fields : BaseModel
    {
        public  string  DataRate { get; set; }
        public  double  Temperature { get; set; }
        public  double  RelativeHumidity { get; set; }
        public  double Smoke_level { get; set; }
    }
}
