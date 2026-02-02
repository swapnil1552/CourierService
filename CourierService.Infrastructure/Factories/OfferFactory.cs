using CourierService.Application.Interfaces.Offers;
using CourierService.Infrastructure.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Infrastructure.Factories
{
    internal class OfferFactory : IOfferFactory
    {
        private readonly Dictionary<string, IOffer> _offers;

        public OfferFactory(IEnumerable<IOffer> offers)
        {
            _offers = offers.ToDictionary(o => o.OfferCode, StringComparer.OrdinalIgnoreCase);
        }
        public IOffer? GetOffer(string offerCode)
        {
            if (string.IsNullOrWhiteSpace(offerCode))
                return null;

            _offers.TryGetValue(offerCode, out var offer);

            return offer;
        }
    }
}
