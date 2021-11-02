using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DegreeConverters;
using FluentAssertions;

namespace DegreeConverters.Tests
{
    [TestFixture]
    public class DegreeConverterTests
    {
        [Test]
        public void ToFahrenheit_ZeroCelcius_Returns32()
        {
            var converter = WithDegreeConverter();
            double result = converter.ToFahrenheit(0);

            //Assert.That(result, Is.EqualTo(32));
            result.Should().Be(32);
        }

        [Test]
        public void ToCelsius_1Fahrenheit_Returns0()
        {
            var converter = WithDegreeConverter();
            double result = converter.ToCelsius(1);

            //Assert.That(result, Is.EqualTo(0));
            result.Should().Be(0);
        }

        private DegreeConverter WithDegreeConverter()
        {
            return new DegreeConverter();
        }
    }
}
