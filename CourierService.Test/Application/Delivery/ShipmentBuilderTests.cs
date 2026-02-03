using CourierService.Application.Services.Delivery;
using CourierService.Domain.Enities;
using FluentAssertions;
using Xunit;
namespace CourierService.UnitTests.Application.Delivery
{
	public class ShipmentBuilderTests
	{
		[Fact]
		public void ShipmentBuilder_ShouldRespect_MaxWeight()
		{
            var packages = new List<Package>
            {
                new Package { Weight = 150 },
                new Package { Weight = 100 },
                new Package { Weight = 90 }
            };

            var builder = new ShipmentBuilder();

            var shipment = builder.GetShipment(packages, 200);

            shipment.TotalWeight.Should().BeLessThanOrEqualTo(200);
        }

        [Fact]
        public void ShipmentBuilder_ShouldChooseOptimalPackages()
        {
            var packages = new List<Package>
            {
                new Package { Id="PKG1", Weight=175, Distance=100 },
                new Package { Id="PKG2", Weight=110, Distance=60 },
                new Package { Id="PKG3", Weight=75, Distance=40 }
            };

            var builder = new ShipmentBuilder();

            var shipment = builder.GetShipment(packages, 200);

            shipment.TotalWeight.Should().Be(185);
        }
    }
}

