using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackTileBackend.IRepositories;
using TrackTileBackend.Models;
using TrackTileBackend.Models.TtnDevices;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TrackTileBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TtnDevicesController : ControllerBase
    {
        private readonly  ITtnDeviceRepository _ittnDeviceRepository ;

        private static IConfiguration _configuration;
        public TtnDevicesController(ITtnDeviceRepository ittnDeviceRepository, IConfiguration configuration)
        {
            _ittnDeviceRepository = ittnDeviceRepository;
            _configuration = configuration;
        }

        [HttpGet("getall")]
        public ActionResult GetDevices()
        {
           return Ok(_ittnDeviceRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public ActionResult GetDevice(int id)
        {
            var help = _ittnDeviceRepository.GetDevice(id);
            if (help != null)
            {
                return Ok(help);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<ActionResult> SaveDevice(TtnData ttnData)
        {
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
                          $"Temperature : {ttnData.Fields.Temperature}\n" +
                          $"Humidity    : {ttnData.Fields.RelativeHumidity}.\n" +
                          $"Smoke level : {ttnData.Fields.Smoke_level}.\n" +
                          $"Contact infor@ibees.org.");
            }
            #endregion
            await _ittnDeviceRepository.Add(ttnData);
            return Ok(ttnData);
        }         
    }
}
