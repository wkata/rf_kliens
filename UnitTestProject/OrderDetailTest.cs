using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kliensalk;
using Moq;
using NUnit.Framework;
using static kliensalk.Form1;

namespace UnitTestProject
{
    public class OrderDetailTest
    {
        private object _orderServiceMock;

        [TestFixture]
        public class Form1Tests
        {
            private Mock<Form1> _formMock;

            [SetUp]
            public void Setup()
            {
                // Mock objektum létrehozása az IOrderService-hez
                _formMock = new Mock<Form1>();
            }


            [Test]
            public async Task Test_GetOrderDetailsAsync_ReturnsValidOrderInfo()
            {
                // Teszt adat
                var orderNumber = "abcd12345678";
                var expectedOrderInfo = new OrderInfo
                {
                    OrderNumber = orderNumber,
                    OrderPlaced = DateTime.Now,
                    Packed = DateTime.Now.AddDays(1),
                    Shipped = DateTime.Now.AddDays(2),
                    Dispatched = DateTime.Now.AddDays(3),
                    Delivered = DateTime.Now.AddDays(4),
                    ExpectedDelivery = DateTime.Now.AddDays(5)
                };

                // Mock beállítása, hogy az `GetOrderDetailsAsync` a várt adatot adja vissza
                _formMock.Setup(service => service.GetOrderDetailsAsync(It.IsAny<string>()))
                                 .ReturnsAsync(expectedOrderInfo);

                // Hívás a mockolt metodusra
                var result = await _formMock.Object.GetOrderDetailsAsync(orderNumber);

                // Ellenőrizzük az eredményt
                Assert.IsNotNull(result);
                Assert.AreEqual(orderNumber, result.OrderNumber);
                Assert.AreEqual(expectedOrderInfo.Delivered.Date, result.Delivered.Date);
            }
        }
    }
}
