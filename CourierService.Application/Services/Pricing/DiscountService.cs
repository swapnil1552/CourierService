using CourierService.Application.Interfaces.Offers;
using CourierService.Application.Interfaces.Pricing;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Services.Pricing
{
    public class DiscountService : IDiscountService
    {
        private readonly IOfferFactory _offerFactory;

        public DiscountService(IOfferFactory offerFactory)
        {
            _offerFactory = offerFactory;
        }
        public double Apply(Package package, double delivertCost)
        {
            var offer = _offerFactory.GetOffer(package.OfferCode);
            if (offer == null || !offer.IsApplicable(package))
            {
                return 0;
            }
            return offer.CalculateDiscount(delivertCost);
        }
    }
}
