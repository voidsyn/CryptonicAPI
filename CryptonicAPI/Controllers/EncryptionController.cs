using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CryptonicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        // 1. KRYPTERING
        // Används så här: /Encryption?text=Hej
        [HttpGet]
        public IActionResult Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Ange text att kryptera: /encryption?text=hemligt");

            string encrypted = ToRovarsprak(text);

            return Ok(new
            {
                Service = "CryptonicAPI",
                Action = "Encryption 🔒",
                Original = text,
                Encrypted = encrypted,
                Type = "Rövarspråket"
            });
        }

        // 2. AVKRYPTERING
        // Används så här: /Encryption/decrypt?text=Hohejoj
        [HttpGet("decrypt")]
        public IActionResult Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Ange text att avkryptera: /encryption/decrypt?text=Hohejoj");

            string decrypted = FromRovarsprak(text);

            return Ok(new
            {
                Service = "CryptonicAPI",
                Action = "Decryption 🔓",
                Original = text,
                Decrypted = decrypted,
                Type = "Rövarspråket"
            });
        }


        // Gör om till Rövarspråket
        private string ToRovarsprak(string input)
        {
            string consonants = "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
            var sb = new StringBuilder();

            foreach (char c in input)
            {
                if (consonants.Contains(c))
                {
                    // Lägg till bokstaven + o + bokstaven igen
                    sb.Append(c + "o" + char.ToLower(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        // Gör om från Rövarspråket
        private string FromRovarsprak(string input)
        {
            string consonants = "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ";
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                sb.Append(c);

                // Om vi hittar en konsonant kollar om det följs av 'o' och samma bokstav
                if (consonants.Contains(c) && i + 2 < input.Length)
                {
                    if (input[i + 1] == 'o' && char.ToLower(input[i + 2]) == char.ToLower(c))
                    {
                        i += 2;
                    }
                }
            }
            return sb.ToString();
        }
    }
}