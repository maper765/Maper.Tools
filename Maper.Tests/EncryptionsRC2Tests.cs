using Maper.Library.EncryptionsHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Maper.Tests
{
    // Organizar, Agir, Afirmar
    [TestClass] 
    public class EncryptionsRC2Tests
    {
        private readonly string _key = "12345678";
        
        private readonly string _valueDecrypt = "texto criptografado";
        private readonly string _valueEncrypt = "213VhNVHoId+FCdpIYAIaPXKwdXou5uW";

        [TestMethod]
        [TestCategory("CryptValidation")]
        public void ExpectedCrypto()
        {
            // Arrange
            var rc2 = new RC2();

            // Act
            var right = rc2.Encrypt(_valueDecrypt, _key);

            // Assert
            Assert.AreEqual(_valueEncrypt, right);
        }

        [TestMethod]
        [TestCategory("CryptValidation")]
        [ExpectedException(typeof(ArgumentException), "Encryption key not entered.")]
        public void KeyIsNotNull()
        {
            // Arrange
            var rc2 = new RC2();

            // Act
            var wrong = rc2.Encrypt(_valueDecrypt, "");

            // Assert - Expects exception
        }
    }
}
