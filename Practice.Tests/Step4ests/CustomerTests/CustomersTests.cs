using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Practice.Step4.Cusomer;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Practice.Tests.Step4Tests.CustomerTests
{
    [TestFixture]
    public class CustomerTestsWithMockingFramework
    {
        const int id = 1;

        [Test]
        public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
        {
            var gateway = Substitute.For<IDbGateway>();
            var workingStatistics = new WorkingStatistics() { PayHourly = true, HourSalary = 100, WorkingHours = 10 };

            gateway.GetWorkingStatistics(id).ReturnsForAnyArgs(workingStatistics);

            const decimal expectedWage = 100 * 10;

            var customer = new Customer(gateway, Substitute.For<ILogger>());
            decimal actual = customer.CalculateWage(id);

            actual.Should().Be(expectedWage);
        }

        [Test]
        public void CalculateWage_PassesCorrectId()
        {
            var gateway = Substitute.For<IDbGateway>();
            gateway.GetWorkingStatistics(id).ReturnsForAnyArgs(new WorkingStatistics());

            var customer = new Customer(gateway, Substitute.For<ILogger>());
            customer.CalculateWage(id);

            gateway.Received().GetWorkingStatistics(id);
        }

        [Test]
        public void CalculateWage_ThrowsException_Returns0()
        {
            var gateway = Substitute.For<IDbGateway>();
            gateway.GetWorkingStatistics(Arg.Any<int>()).Throws(new InvalidOperationException());

            var customer = new Customer(gateway, Substitute.For<ILogger>());

           // decimal actual = customer.CalculateWage(id);
            decimal actual1 = customer.CalculateWage(Arg.Any<int>());

            actual1.Should().Be(0);
            //actual.Should().Be(0);
        }
    }

    [TestFixture]
    public class CustomersTests
    {
        const int id = 1;

        [Test]
        public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
        {
            DbGatewayStub dbGateway = new DbGatewayStub();
            dbGateway.SetWorkingStatistics(new WorkingStatistics() { PayHourly = true, HourSalary = 100, WorkingHours = 10 });

            var customer = new Customer(dbGateway, new LoggerDummy());

            decimal actual = customer.CalculateWage(id);

            const decimal expectedWage = 100 * 10;
            actual.Should().Be(expectedWage);
            //actual.Should().BeApproximately(expectedWage, 0.1); float
        }

        [Test]
        public void CalculateWage_PassesCorrectId()
        {
            var gateway = new DbGatewaySpy();
            gateway.SetWorkingStatistics(new WorkingStatistics());

            var customer = new Customer(gateway, new LoggerDummy());

            customer.CalculateWage(id);

            gateway.Id.Should().Be(1);
        }

        [Test]
        public void CalculateWage_PassesCorrectId2()
        {
            var gateway = new DbGatewayMock();
            gateway.SetWorkingStatistics(new WorkingStatistics());

            var customer = new Customer(gateway, new LoggerDummy());

            customer.CalculateWage(id);

            gateway.VerifyCalledWithProperId(id).Should().Be(true);
        }

        [Test]
        public void CalculateWage_WithFakeData()
        {
            const int id2 = 2;

            var dbGateway = new DbGatewayFake();
            dbGateway.GetWorkingStatistics(id);

            var customer = new Customer(dbGateway, new LoggerDummy());

            customer.CalculateWage(id).Should().Be(500);
            customer.CalculateWage(id2).Should().Be(3000);
        }
    }
}
