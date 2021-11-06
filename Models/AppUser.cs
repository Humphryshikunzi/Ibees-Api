using Microsoft.AspNetCore.Identity;

namespace TrackTileBackend.Models
{
    public class AppUser : IdentityUser
    {
        public  string  Role { get; set; }
        public  string  AuthKey { get; set; }
        public   bool  IsSignedIn { get; set; }
        public  string  ProfileImagePath { get; set; }
        public bool TermsTermsAndConditionsChecked { get; set; }
        public string Town { get; set; }
        public  Setting  Setting { get; set; }        
    }
}
