namespace TrackTileBackend.Models.TtnDevices
{
    public class TtnData : BaseModel
    {
        public string  Time { get; set; }
        public string Measurement { get; set; }
        public Fields Fields { get; set; }
        public Tags Tags { get; set; }
    }
}
