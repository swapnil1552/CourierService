using CourierService.Application.Interfaces.Delivery;
using CourierService.Application.Services.Delivery;
using CourierService.Domain.Enities;
using FluentAssertions;
using Moq;
using Xunit;
namespace CourierService.Tests.Application.Delivery
{
	public class DeliverySchedulerTests
	{
		[Fact]
		public void DeliveryScheduler_ShouldSetEstimatedDeliveryTime()
		{
            var pkg = new Package { Weight = 50, Distance = 30 };

			var shipment = new Shipment();

			shipment.AddPackage(pkg);

			var builderMock = new Mock<IShipmentBuilder>();
			builderMock.Setup(x => x.GetShipment(It.IsAny<List<Package>>(), It.IsAny<double>())).Returns(shipment);

			var scheduler = new DeliveryScheduler(builderMock.Object);

            var vehicle = new Vehicle
            {
                Speed = 70,
                MaxWeight = 200
            };

			scheduler.Schedule(new List<Package> { pkg }, new List<Vehicle> { vehicle });

			pkg.EstimatedDeliveryTime.Should().Be(0.42);

        }

        [Fact]
        public void Scheduler_ShouldPickVehicle_WithLowestAvailability()
        {
            #region Package Data
            var pkg = new Package
            {
                Id = "PKG1",
                Weight = 50,
                Distance = 30,
                OfferCode = "OFR001"
            };

            var pkg2 = new Package
            {
                Id = "PKG2",
                Weight = 75,
                Distance = 125,
                OfferCode = "OFR0008"
            };

            var pkg3 = new Package
            {
                Id = "PKG3",
                Weight = 175,
                Distance = 100,
                OfferCode = "OFR003"
            };

            var pkg4 = new Package
            {
                Id = "PKG4",
                Weight = 110,
                Distance = 60,
                OfferCode = "OFR002"
            };
            var pkg5 = new Package
            {
                Id = "PKG5",
                Weight = 155,
                Distance = 95,
                OfferCode = "NA"
            };
            #endregion

            var shipment = new Shipment();
            shipment.AddPackage(pkg);
            shipment.AddPackage(pkg2);
            shipment.AddPackage(pkg3);
            shipment.AddPackage(pkg4);
            shipment.AddPackage(pkg5);

            var builderMock = new Mock<IShipmentBuilder>();
            builderMock.Setup(b => b.GetShipment(It.IsAny<List<Package>>(), It.IsAny<double>()))
                       .Returns(shipment);

            var scheduler = new DeliveryScheduler(builderMock.Object);
                
            var v1 = new Vehicle { Speed = 70, MaxWeight = 200, AvailableAt = 0 };
            var v2 = new Vehicle { Speed = 70, MaxWeight = 200, AvailableAt = 0 };

            scheduler.Schedule(new List<Package> { pkg, pkg2, pkg3, pkg4, pkg5 }, new List<Vehicle> { v1, v2 });

            v1.AvailableAt.Should().Be(3.56);
        }

    }
}

