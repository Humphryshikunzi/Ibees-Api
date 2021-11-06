namespace TrackTileBackend.Models
{
    public class Setting : BaseModel
    {
        public bool AppNotificationsOn { get; set; }
        public bool MarkettingNotificationsOn { get; set; }
        public bool NightModeOn { get; set; }
    }
}
