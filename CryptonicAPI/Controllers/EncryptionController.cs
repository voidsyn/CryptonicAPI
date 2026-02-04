using Microsoft.AspNetCore.Mvc;

namespace CryptonicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Ange text att kryptera: /encryption?text=hemligt");

            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            string encrypted = new string(charArray);

            return Ok(new
            {
                Service = "CryptonicAPI",
                Region = "Stockholm",
                Original = text,
                Encrypted = encrypted
            });
        }
    }
}