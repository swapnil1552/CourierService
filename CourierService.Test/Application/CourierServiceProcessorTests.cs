using CourierService.Application.Interfaces.Delivery;
using CourierService.Application.Interfaces.Offers;
using CourierService.Application.Interfaces.Pricing;
using CourierService.Application.Services;
using CourierService.Application.Services.Pricing;
using CourierService.Domain.Enities;
using CourierService.Infrastructure.Offers;
using FluentAssertions;
using Moq;
using Xunit;
namespace CourierService.UnitTests.Application
{
    public class CourierServiceProcessorTests
    {
        [Fact]
        public void Processor_ShouldCalculateTotalCost()
        {
            var discountMock = new Mock<IDiscountService>();
            var offerFactoryMock = new Mock<IOfferFactory>();

            offerFactoryMock
            .Setup(f => f.GetOffer(It.IsAny<string>()))
            .Returns<string>(code =>
            {
                return code switch
                {
                    "OFR001" => new OfferOFR001(),
                    "OFR002" => new OfferOFR002(),
                    "OFR003" => new OfferOFR003(),
                    _ => null
                };
            });

            #region Comment
            //discountMock.Setup(d => d.Apply(It.IsAny<Package>(), It.IsAny<double>()))
            //.Returns(100);
            //offerFactoryMock.Setup(x => x.GetOffer("OFR001")).Returns(new OfferOFR001());
            //offerFactoryMock.Setup(x => x.GetOffer("OFR002")).Returns(new OfferOFR002());
            //offerFactoryMock.Setup(x => x.GetOffer("OFR003")).Returns(new OfferOFR003());
            #endregion 


            var discountService = new DiscountService(offerFactoryMock.Object);

            var calculator = new DeliveryCostCalculator();

            var schedulerMock = new Mock<IDeliveryScheduler>();

            var processor = new CourierServiceProcessor(discountService, calculator, schedulerMock.Object);

            #region package data
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

            #region vehicle Data
            var vec1 = new Vehicle
            {
                Speed = 70,
                MaxWeight = 200
            };
            

            var vec2 = new Vehicle
            {
                Speed = 70,
                MaxWeight = 200
            };
            #endregion

            processor.Process(new List<Package> { pkg, pkg2, pkg3, pkg4, pkg5 }, new List<Vehicle> { vec1, vec2}, 100);

            pkg.TotalCost.Should().Be(750);
            pkg2.TotalCost.Should().Be(1475);
            pkg3.TotalCost.Should().Be(2350);
            pkg4.TotalCost.Should().Be(1395);
            pkg5.TotalCost.Should().Be(2125);

            pkg4.Discount.Should().Be(105);
        }
    }
}

