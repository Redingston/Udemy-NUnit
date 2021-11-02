using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace RomanNumeral.Tests
{
    [TestFixture]
    public class RomanNumeralTests
    {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("II", 2)]
        [TestCase("IV", 4)]
        [TestCase("DC", 600)]
        [TestCase("IX", 9)]
        public void Parse_Test(string inputString, int expected)
        {
            RomanNumeral.Parse(inputString).Should().Be(expected);
        }
    }
}
