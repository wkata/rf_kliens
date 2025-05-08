using kliensalk;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kliensalk.Form1;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace UnitTestProject.Tests
{
    
    public class OrderDetailTest
    {
        [TestFixture]
        public class OrderValidatorTests
        {
            [TestCase("123456789012", true)]        // helyes
            [TestCase("12345abc9012", false)]       // betű van benne
            [TestCase("1234567890", false)]         // túl rövid
            [TestCase("", false)]
            [TestCase(null, false)]
            public void IsValidOrderNumber_ReturnsExpected(string input, bool expected)
            {
                // act
                bool result = OrderValidator.IsValidOrderNumber(input);

                // assert
                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
