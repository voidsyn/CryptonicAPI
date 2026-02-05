#nullable disable
using Xunit;
using CryptonicAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CryptonicAPI.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void Encrypt_ShouldReturnRovarsprak()
        {
            // 1. ARRANGE
            var controller = new EncryptionController();
            string input = "Hej";
            string expected = "Hohejoj";

            // 2. ACT
            var result = controller.Encrypt(input) as OkObjectResult;

            // 3. ASSERT
            Assert.NotNull(result); 

            Assert.Contains(expected, result.Value.ToString());
        }

        [Fact]
        public void Decrypt_ShouldReturnOriginal()
        {
            // 1. ARRANGE
            var controller = new EncryptionController();
            string input = "Hohejoj";
            string expected = "Hej";

            // 2. ACT
            var result = controller.Decrypt(input) as OkObjectResult;

            // 3. ASSERT
            Assert.NotNull(result);
            Assert.Contains(expected, result.Value.ToString());
        }
    }
}