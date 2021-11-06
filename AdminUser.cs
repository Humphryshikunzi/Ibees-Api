using TrackTileBackend.Constants;
using TrackTileBackend.Models;

namespace TrackTileBackend.Data
{
    public static class AdminUser
    {
        public static AppUser Admin = new AppUser()
        {
            PasswordHash = "2288Shiks.",
            UserName = "Humphryshikunzi",
            Email = "humphry.shikunzi@outlook.com",
            Role = Roles.Admin
        };
    }
}
