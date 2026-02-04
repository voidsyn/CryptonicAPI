using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CryptonicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string text)
        {
            // Om ingen text skickas med
            if (string.IsNullOrEmpty(text))
                return BadRequest("Ange text att kryptera: /encryption?text=hemligt");

            // Anropar vi funktionen
            string encrypted = ToRovarsprak(text);

            return Ok(new
            {
                Service = "CryptonicAPI",
                Region = "Stockholm",
                Original = text,
                Encrypted = encrypted,
                Type = "Rövarspråket 🏴‍☠️"
            });
        }

        // logiken för Rövarspråket
        private string ToRovarsprak(string input)
        {
            // Lista på alla konsonanter
            string consonants = "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
            var sb = new StringBuilder();

            foreach (char c in input)
            {
                // Om bokstaven är en konsonant: Lägg till 'o' och bokstaven igen
                if (consonants.Contains(c))
                {
                    sb.Append(c + "o" + char.ToLower(c));
                }
                else
                {
                    // Om det är en vokal (eller annat tecken): Låt den vara
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}