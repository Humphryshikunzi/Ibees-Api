namespace TrackTileBackend.Models.SigfoxDevices
{
    public class SigfoxDevice : BaseModel
    {
        public string Device { get; set; }
        public string Time { get; set; }
        public string SeqNumber { get; set; }
        public string DeviceTypeId { get; set; }
        public double Temp { get; set; }
        public double Hum { get; set; }
        public double SmokeLevel {get;set;}
        public int QueenState { get; set; }
        public int Knock { get; set; }
    }
}
