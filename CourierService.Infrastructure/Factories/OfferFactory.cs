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
        public IOffer GetOffer(string offerCode)
        {
            IOffer offer = null;
            switch (offerCode)
            {
                case "OFR001":
                    offer =  new OfferOFR001();
                    break;
                case "OFR002":
                    offer =  new OfferOFR002();
                    break;
                case "OFR003":
                    offer =  new OfferOFR003();
                    break;

            }

            return offer;
        }
    }
}
