using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using TrackTileBackend.Models;
using TrackTileBackend.Models.SigfoxDevices;

namespace TrackTileBackend.Services
{
    public static  class EmailServices
    {
        public static  string PasswordRecoveryMail(string email)
        {
            var generatedCode = GeneratePasswordRecoveryCode();
            try
            {
                var credentials = new NetworkCredential("reaiotorg@gmail.com", "magic@3.");
                var mail = new MailMessage()
                {
                    From = new MailAddress("reaiotorg@gmail.com"),
                    Subject = "Password Recovery",
                    Body = $"<h4>Hello, </h4> Welcome to Tracktile. <br>  Your password recovery code is <strong> { generatedCode } </strong> <br> <br> Thank you. <br> <br> Regards, <br><br> Humphry Shikunzi <br> IT Manager <br> Nyeri,  Kenya" 
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(email));
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
                return generatedCode;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private  static string GeneratePasswordRecoveryCode()
        {
            var rand = new Random();
            var  code = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                var randomNum = rand.Next(0, 9);
                code.Append(randomNum);
            }
            return  code.ToString();
        }
        public static void AccountConfirmationMail(AppUser appUser)
        {
            try
            {
                var credentials = new NetworkCredential("reaiotorg@gmail.com", "magic@3.");
                var mail = new MailMessage()
                {
                    From = new MailAddress("reaiotorg@gmail.com"),
                    Subject = "Tracktile Account",
                    Body = $"<h4>Hello {appUser.UserName },</h4>< p > Welcome to Tracktile.</ p >< p > An account has been created for you with email : {appUser.Email}.</ p >< p > Kindly activate the account using this link < a href = \"https://reaiot.com/\"> activation </ a ></ p > < p > Kindly note that the link expires after 7 days.</ p > < br >< p > Thanks.</ p >< br >< p > Regards,</ p >< br >< p > Humphry Shikunzi </ p >< P > IT Manager </ P >< p > Nyeri, Kenya </ p > "
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(appUser.Email));
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string MailTestForTTN(TttnTestData tttnTestData)
        {
            var generatedCode = GeneratePasswordRecoveryCode();
            try
            {
                var credentials = new NetworkCredential("reaiotorg@gmail.com", "magic@3.");
                var mail = new MailMessage()
                {
                    From = new MailAddress("reaiotorg@gmail.com"),
                    Subject = "Password Recovery",
                    Body = $"<h4>Hello, </h4> Welcome to Tracktile. <br> This is the test data <br> dev_id  {tttnTestData.dev_id} <br> app_id {tttnTestData.app_id} <br> relative_humidity_3 {tttnTestData.payload_fields.relative_humidity_3} <br> temperature_2 {tttnTestData.payload_fields.temperature_2} <br> Thank you. <br> <br> Regards, <br><br> Humphry Shikunzi <br> IT Manager <br> Nyeri,  Kenya"
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("humphry97@outlook.com"));
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
                return generatedCode;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static string MailTestForSigfox(SigfoxDevice sigfoxDevice)
        {
            var generatedCode = GeneratePasswordRecoveryCode();
            try
            {
                var credentials = new NetworkCredential("reaiotorg@gmail.com", "magic@3.");
                var mail = new MailMessage()
                {
                    From = new MailAddress("reaiotorg@gmail.com"),
                    Subject = "Password Recovery",
                    Body = $"<h4>Hello, </h4> Welcome to Tracktile. <br> This is the test data <br> dev_id  {sigfoxDevice.DeviceTypeId} <br>  device {sigfoxDevice.Device} <br> relative_humidity {sigfoxDevice.Hum} <br> temperature {sigfoxDevice.Temp} <br> Thank you. <br> <br> Regards, <br><br> Humphry Shikunzi <br> IT Manager <br> Nyeri,  Kenya"
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress("humphry97@outlook.com"));
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                client.Send(mail);
                return generatedCode;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
