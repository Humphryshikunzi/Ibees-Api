using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackTileBackend.IRepositories;
using TrackTileBackend.Models;
using TrackTileBackend.Models.SigfoxDevices;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace  TrackTileBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesRepository _devicesRepository;
        private static IConfiguration _configuration;

        public DevicesController(IDevicesRepository devicesRepository, IConfiguration configuration)
        {
            _devicesRepository = devicesRepository;
            _configuration = configuration;
        }

        [HttpGet("getall")]
        public ActionResult GetDevices()
        {
           return Ok(_devicesRepository.GetDevices());
        }

        [HttpGet("sigfox/getall")]
        public ActionResult GetSigfoxDevices()
        {
            return Ok(_devicesRepository.GetSigfoxDevices());
        }

        [HttpGet("sigfox/lastElements/{totalNo}")]
        public ActionResult GetLastElements(int totalNo)
        {
            return Ok(_devicesRepository.GetLastElements(totalNo));
        }

        [HttpGet("sigfox/Elements/{from}/{to}")]
        public ActionResult GetSelectedElements(int from, int to)
        {
            return Ok(_devicesRepository.GetSomeSigfoxDevicesData(from,to));
        }

        [HttpGet("get/{id}")]
        public ActionResult GetDevice(int id)
        {
            var help = _devicesRepository.GetDevice(id);
            if (help != null)
            {
                return Ok(help);
            }
            return NotFound();
        }


        [HttpPost("add")]
        public async Task<ActionResult> SaveDevice(TttnTestData tttnTestData)
        {
            await _devicesRepository.SaveDeviceData(tttnTestData);

            //This code sends me a message before saving to database
            #region Send Message to IBees
            // Get credentials for Twilio
            var twilioCredentials = _configuration.GetSection("TwilioCredentials");
            var twilioDto = twilioCredentials.Get<TwilioDto>();

            TwilioClient.Init(twilioDto.AccountSSD, twilioDto.AuthToken);


            //dictionary of people to send the messages to 
            var people = new Dictionary<string, string>()
            {
                { "+254742267032","Humphry" }
            };

            foreach (var person in people)
            {
                MessageResource.Create(
                    from: new PhoneNumber("+12056565415"),
                    to: new PhoneNumber(person.Key),
                    body: $"Hello, message from Ibees\n." +
                          $"Bee hive 001 Notification : \n" +
                          $"Temperature : {tttnTestData .payload_fields.temperature_2}\n" +
                          $"Humidity    : {tttnTestData.payload_fields.relative_humidity_3}\n" +
                          $"Smoke level : {tttnTestData.payload_fields.smooke_level}\n" +
                          $"Contact infor@ibees.org.");
            }
            #endregion
            return Ok(tttnTestData);
        }

        [HttpPost("sigfox/add")]
        [AllowAnonymous]
        public async Task<ActionResult> SaveSigfoxDevice(SigfoxDevice sigfoxDevice)
        {

            await _devicesRepository.AddSigfoxDevice(sigfoxDevice);

            //This code sends me a message before saving to database
            /*
            #region Send Message to IBees
            // Get credentials for Twilio
            var twilioCredentials = _configuration.GetSection("TwilioCredentials");
            var twilioDto = twilioCredentials.Get<TwilioDto>();

            TwilioClient.Init(twilioDto.AccountSSD, twilioDto.AuthToken);
            sigfoxDevice.SmokeLevel = sigfoxDevice.SmokeLevel * 4;

            //dictionary of people to send the messages to 
            var people = new Dictionary<string, string>()
            {
                { "+254720241562 ", "Clinton Oduor" } 
            };

            foreach (var person in people)
            {
                MessageResource.Create(
                    from: new PhoneNumber("+14256516741"),
                    to: new PhoneNumber(person.Key),
                   body: $"\nIbees beehive alert!\n" +
                          $"Hive is too hot, Bees might fly away\n");
            }

            // Temperature
            if (sigfoxDevice.Temp > 35)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+4256516741"), 
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n"+
                              $"Hive is too hot, Bees might fly away\n");
                }
            }

            else if (sigfoxDevice.Temp < 13)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Hive is too cold, Bees might freeze to death\n");
                }
            }

            // Smoke
            if (sigfoxDevice.SmokeLevel > 250)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Smoke Detected(Possible theft or bush fire)\n");
                }
            }


            //knock
            if (sigfoxDevice.Knock == 1)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Beehive knocked over, about to be stolen\n");
                }
            }

            // queenState
            if (sigfoxDevice.QueenState == 1)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Queen not laying eggs(Queen not present)\n");
                }
            }

            else if (sigfoxDevice.QueenState == 2)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Possible swarming detected\n");
                }
            }


            // humidity
            if (sigfoxDevice.Hum > 60)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Beehive too dumpy, this may lead to pest and disease infestation, fungal and moulds growth\n");
                }
            }

            else if (sigfoxDevice.Hum < 50)
            {
                foreach (var person in people)
                {
                    MessageResource.Create(
                        from: new PhoneNumber("+13235534645"),
                        to: new PhoneNumber(person.Key),
                       body: $"\nIbees beehive alert!\n" +
                              $"Hive Humidity too low\n");
                }
            }
            #endregion
            */
            return Ok(sigfoxDevice);
        }


        [HttpPut("update")]
        public async Task<ActionResult> UpDateDevice(TttnTestData tttnTestData)
        {
            await _devicesRepository.UpDateDevice(tttnTestData);
            return Ok(tttnTestData);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteDevice(int id)
        {
            var help = _devicesRepository.GetDevice(id);
            if (help != null)
            {
                 _devicesRepository.DeleteDevice(id);
                return Ok(help);
            }
            return BadRequest();
        }
    }
}
