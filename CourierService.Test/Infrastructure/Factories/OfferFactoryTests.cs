using CourierService.Application.Interfaces.Offers;
using CourierService.Infrastructure.Factories;
using CourierService.Infrastructure.Offers;
using FluentAssertions;
using Xunit;

namespace CourierService.UnitTests.Infrastructure.Factories
{
	public class OfferFactoryTests
	{
        [Fact]
        public void OfferFactory_ShouldReturn_OFR001()
        {
            var offers = new List<IOffer>
            {
                new OfferOFR001(),
                new OfferOFR002()
            };

            var factory = new OfferFactory(offers);

            var offer = factory.GetOffer("OFR001");

            offer.Should().NotBeNull();
            offer!.OfferCode.Should().Be("OFR001");
        }

        [Fact]
        public void OfferFactory_ShouldReturnNull_WhenInvalid()
        {
            var factory = new OfferFactory(new List<IOffer>());

            var offer = factory.GetOffer("INVALID");

            offer.Should().BeNull();
        }
    }
}

