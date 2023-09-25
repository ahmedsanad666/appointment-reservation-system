using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Jwt.AccessToken;
using Twilio;
using Microsoft.OpenApi.Writers;
using Twilio.Rest.Video.V1.Room;

using Twilio.Rest.Insights.V1;
using System.Text;
using Twilio.TwiML.Voice;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTokenController : ControllerBase
    {
        private const string TwilioAccountSid = "AC0782e5ca34056f5f3e8b35e44dfa5c4d";
        private const string TwilioAuthToken = "1adc9bf8b025612f95f72a418f13c83e";

        // create room 

        [HttpPost]
        public async Task<ActionResult> CreateRoom()
        {
            string roomName = Guid.NewGuid().ToString(); // Generate a unique room name

            string url = $"https://video.twilio.com/v1/Rooms";
            string requestBody = $"UniqueName={roomName}&Type=go";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"{TwilioAccountSid}:{TwilioAuthToken}")
                ));

                var content = new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded");
                var response = await client.PostAsync(url, content);
             
                if (response.IsSuccessStatusCode)
                {
                     
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var grant = new VideoGrant();
                    grant.Room = "cool room";

                   
                    var grants = new HashSet<IGrant> { grant };
                    var token = new Token(
                     TwilioAccountSid,
                     "SK5477acd2a77c2bac3d06219ae687c2d7", // Replace with your API Key SID
                     "LJrh2wl8tnHT75tPfAKysToWNtUeHUSA",
                      grants: grants

     // Replace with your API Key Secret
     );
                    return Ok(new { RoomId = roomName, token = token.ToJwt()});
                }
                else
                {
                    return BadRequest("Failed to create room.");
                }
            }
        }

            [HttpGet]
        public async Task<ActionResult> GetTwilioAccessToken()
        {
            // Initialize the Twilio client
            TwilioClient.Init(TwilioAccountSid, TwilioAuthToken);

            // Create a capability token
            var grant = new VideoGrant();
            //grant.OutgoingApplicationSid = "AC0782e5ca34056f5f3e8b35e44dfa5c4d"; // Replace with your Twilio Application SID
            //grant.IncomingAllow = true;
            var grants = new HashSet<IGrant>
        {
            { grant }
        };
            // Create an access token
            var token = new Token(
                TwilioAccountSid,
                "SK5477acd2a77c2bac3d06219ae687c2d7", // Replace with your API Key SID
                "LJrh2wl8tnHT75tPfAKysToWNtUeHUSA",
                grants: grants
            // Replace with your API Key Secret
            );

            // Serialize the token and send it as JSON
            return Ok(new { token = token.ToJwt() });
        }
    }
}
