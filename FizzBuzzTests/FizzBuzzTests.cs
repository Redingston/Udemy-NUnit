using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace FizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(20, "Buzz")]
        [TestCase(1, "")]
        [TestCase(11, "")]
        public void Ask_Number_ReturnsCorrectString(int number, string expectedString)
        {
            //    var result = FizzBuzz.Ask(number);
            //    result.Should().Be(expectedString);

            FizzBuzz.Ask(number).Should().Be(expectedString);
        }
    }
}
