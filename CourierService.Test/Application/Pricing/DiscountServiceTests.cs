using CourierService.Application.Interfaces.Offers;
using CourierService.Application.Services.Pricing;
using CourierService.Domain.Enities;
using FluentAssertions;
using Moq;
using Xunit;

namespace CourierService.UnitTests.Application.Pricing
{
	public class DiscountServiceTests
	{
		[Fact]
		public void DiscountService_ShouldReturnZero_WhenOfferNotFound()
		{
			var factoryMock = new Mock<IOfferFactory>();
			factoryMock.Setup(x => x.GetOffer(It.IsAny<string>())).Returns((IOffer)null);

			var service = new DiscountService(factoryMock.Object);

			var pkg = new Package();

			var result = service.Apply(pkg, 500);

			result.Should().Be(0);
		}

		[Fact]
		public void DiscountService_ShouldApplyDiscount()
		{
			var offer = new CourierService.Infrastructure.Offers.OfferOFR003();

			var factoryMock = new Mock<IOfferFactory>();
			factoryMock.Setup(x => x.GetOffer("OFR003")).Returns(offer);

			var service = new DiscountService(factoryMock.Object);

			var pkg = new Package
			{
				Weight = 50,
				Distance = 100,
				OfferCode = "OFR003"
			};

			var discount = service.Apply(pkg, 1000);

			discount.Should().Be(50);
		}
    }
}

