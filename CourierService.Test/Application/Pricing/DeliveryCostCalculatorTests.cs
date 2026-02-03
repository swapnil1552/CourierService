using System;
using CourierService.Application.Services.Pricing;
using CourierService.Domain.Enities;
using FluentAssertions;

namespace CourierService.UnitTests.Application.Pricing
{
	public class DeliveryCostCalculatorTests
	{
		[Fact]
		public void CalculatePackageCost_ShouldReturnCorrectValue()
		{
            var calculator = new DeliveryCostCalculator();

            var package = new Package
            {
                Weight = 10,
                Distance = 100
            };

            var result = calculator.CalculatePackageCost(package, 100);

            result.Should().Be(100 + (10 * 10) + (100 * 5));

        }

    }
}

