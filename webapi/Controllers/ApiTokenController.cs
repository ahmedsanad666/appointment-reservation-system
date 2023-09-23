using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Jwt.AccessToken;
using Twilio;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTokenController : ControllerBase
    {
        private const string TwilioAccountSid = "AC0782e5ca34056f5f3e8b35e44dfa5c4d";
        private const string TwilioAuthToken = "604fcd6c34ff7a402a86c99f4a0e4e6f";


        [HttpGet]
        public async Task<ActionResult> GetTwilioAccessToken()
        {
            // Initialize the Twilio client
            TwilioClient.Init(TwilioAccountSid, TwilioAuthToken);

            // Create a capability token
            var grant = new VoiceGrant();
            grant.OutgoingApplicationSid = "AC0782e5ca34056f5f3e8b35e44dfa5c4d"; // Replace with your Twilio Application SID
            grant.IncomingAllow = true;
            var grants = new HashSet<IGrant>
        {
            { grant }
        };
            // Create an access token
            var token = new Token(
                TwilioAccountSid,
                "SKcfa3030dd492d3cda825b5a48d136532", // Replace with your API Key SID
                "pHs5eLU8Ha0JJ5Rm0KEjnHk3prLpLoPe",
                grants: grants
            // Replace with your API Key Secret
            );

            // Serialize the token and send it as JSON
            return Ok(new { token = token.ToJwt() });
        }
    }
}
