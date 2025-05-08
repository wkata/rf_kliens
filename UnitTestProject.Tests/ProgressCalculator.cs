using kliensalk;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kliensalk.Form1;



namespace UnitTestProject.Tests
{


    public static class ProgressCalculator
    {
        public static int CalculateProgress(OrderInfo order)
        {
            int progress = 0;

            if (order.OrderPlaced != DateTime.MinValue)
                progress = 20;
            if (order.Packed != DateTime.MinValue)
                progress = 40;
            if (order.Shipped != DateTime.MinValue)
                progress = 60;
            if (order.Dispatched != DateTime.MinValue)
                progress = 80;
            if (order.Delivered != DateTime.MinValue)
                progress = 100;

            return progress;
        }
    }

    [TestFixture]
   
        public class ProgressCalculatorTests
        {
            public static IEnumerable<TestCaseData> ProgressTestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new Form1.OrderInfo(), 0);

                    yield return new TestCaseData(
                        new Form1.OrderInfo { OrderPlaced = DateTime.Now }, 20);

                    yield return new TestCaseData(
                        new Form1.OrderInfo { OrderPlaced = DateTime.Now, Packed = DateTime.Now }, 40);

                    yield return new TestCaseData(
                        new Form1.OrderInfo { OrderPlaced = DateTime.Now, Packed = DateTime.Now, Shipped = DateTime.Now }, 60);

                    yield return new TestCaseData(
                        new Form1.OrderInfo { OrderPlaced = DateTime.Now, Packed = DateTime.Now, Shipped = DateTime.Now, Dispatched = DateTime.Now }, 80);

                    yield return new TestCaseData(
                        new Form1.OrderInfo { OrderPlaced = DateTime.Now, Packed = DateTime.Now, Shipped = DateTime.Now, Dispatched = DateTime.Now, Delivered = DateTime.Now }, 100);
                }
            }

            [Test, TestCaseSource(nameof(ProgressTestCases))]
            public void CalculateProgress_ReturnsCorrectPercentage(Form1.OrderInfo input, int expectedProgress)
            {
                // Act
                int actual = ProgressCalculator.CalculateProgress(input);

                // Assert
                Assert.That(actual, Is.EqualTo(expectedProgress));
            }
        }
    }


