using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Data;
using MimeKit;
using Servicios;

namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        private Mock<AccessConnection> _mockAccessConnection;
        private MailFunctions _mailFunctions;
        private MailSettings _settings;

        [TestInitialize]
        public void Setup()
        {
            _settings = new MailSettings();
            _mockAccessConnection = new Mock<AccessConnection>(_settings);
            _mailFunctions = new MailFunctions(_settings);
            typeof(MailFunctions)
                .GetField("_accessConnection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(_mailFunctions, _mockAccessConnection.Object);
        }

        [TestMethod]
        public async Task SendMultipleEmails_CallsSendEmail()
        {
            var recipients = new List<string> { "test@mail.com" };
            string subject = "Test";
            string body = "Body";
            int quantity = 1;

            _mockAccessConnection.Setup(x => x.sendEmail(recipients, subject, body, quantity)).Returns(Task.CompletedTask);

            await _mailFunctions.SendMultipleEmails(recipients, subject, body, quantity);

            _mockAccessConnection.Verify(x => x.sendEmail(recipients, subject, body, quantity), Times.Once);
        }

        [TestMethod]
        public async Task FilteredEmail_ReturnsMimeMessage()
        {
            var expected = new MimeMessage();
            _mockAccessConnection.Setup(x => x.getLastEmail("filtro")).ReturnsAsync(expected);

            var result = await _mailFunctions.filteredEmail("filtro");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task ShowLastEmail_ReturnsTextBody()
        {
            var message = new MimeMessage();
            message.Body = new TextPart("plain") { Text = "Cuerpo" };
            _mockAccessConnection.Setup(x => x.getLastEmail("filtro")).ReturnsAsync(message);

            var result = await _mailFunctions.showLastEmail("filtro");

            Assert.AreEqual("Cuerpo", result);
        }

        [TestMethod]
        public async Task ShowLastEmail_ReturnsErrorMessageIfNull()
        {
            _mockAccessConnection.Setup(x => x.getLastEmail("filtro")).ReturnsAsync((MimeMessage)null);

            var result = await _mailFunctions.showLastEmail("filtro");

            Assert.AreEqual("No se encontró correo con ese filtro.", result);
        }
    }
}
