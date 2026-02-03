using System;
using CourierService.Domain.Enities;
using FluentAssertions;
using Xunit;
namespace CourierService.UnitTests.Domain
{
	public class ShipmentTests
	{
		[Fact]
		public void Shipment_ShouldAddPackage()
		{
			var shipment = new Shipment();
			var pkg = new Package { Weight = 10 };

			shipment.AddPackage(pkg);

			shipment.Packages.Should().Contain(pkg);
		}

		[Fact]
		public void Shipment_ShouldRemoveLastPackage()
		{
			var shipment = new Shipment();

			shipment.AddPackage(new Package());
			shipment.AddPackage(new Package());

			shipment.RemoveLastPackage();

			shipment.Packages.Count.Should().Be(1);
		}

        [Fact]
        public void Shipment_TotalWeight_ShouldBeCorrect()
        {
            var shipment = new Shipment();

            shipment.AddPackage(new Package { Weight = 10 });
            shipment.AddPackage(new Package { Weight = 20 });

            shipment.TotalWeight.Should().Be(30);
        }
    }
}

