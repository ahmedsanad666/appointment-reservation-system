using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Net.Http;

using System.Text;
using webapi.Models;
using System;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly string appId = "f4502f04da9d4a51a439141d140772b7"; // Replace with your Agora App ID
        private readonly string appCertificate = "43ade1f50b544a7686964e7b38cbe06e"; // Replace with your Agora App Certificate


        [HttpPost]
        public IActionResult GenerateToken([FromBody] TokenRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Uid))
            {
                return BadRequest("Invalid request");
            }

            string channelName = request.ChannelName; // Use a shared or default channel name
            string userId = request.Uid;
            uint expirationTimeInSeconds = 3600; // Token expiration time (in seconds)

            var key = Encoding.UTF8.GetBytes(appCertificate);
            using var hmac = new HMACSHA256(key);
            uint timestamp = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            uint expirationTimestamp = timestamp + expirationTimeInSeconds;

            var content = $"{appId}{channelName}{userId}{timestamp}{expirationTimestamp}";
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(content));
            var token = Convert.ToBase64String(hash);

            return Ok(new { token });
        }
    }
}




