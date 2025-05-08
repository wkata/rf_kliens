    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    internal class OrderValidator
    {

        public static bool IsValidOrderNumber(string input)
        {
            return !string.IsNullOrEmpty(input) &&
          input.Length == 12 &&
          input.All(char.IsDigit);
        }
    }
    }
