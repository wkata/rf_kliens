using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static kliensalk.Form1;
using kliensalk;
using Moq.Protected;
using System.Threading;
namespace UnitTestProject.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private HttpClient _httpClient;
        private Form1 _form1;

        [SetUp]
        public void Setup()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://rendfejl1012.northeurope.cloudapp.azure.com/") // Add meg az alaphostot, ha a metódus csak path-ot kapna
            };

            _form1 = new Form1(_httpClient);
        }

        

        [Test]
        public async Task GetOrderDetailsAsync_InvalidOrderNumber_ShouldReturnNull()
        {
            // Arrange
            string invalidOrderNumber = "invalid123";

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            // Act
            var result = await _form1.GetOrderDetailsAsync(invalidOrderNumber);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}