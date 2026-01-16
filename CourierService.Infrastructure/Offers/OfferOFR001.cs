using CourierService.Application.Interfaces.Offers;
using CourierService.Application.Services.Pricing;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Infrastructure.Offers
{
    public class OfferOFR001 : IOffer
    {
        private readonly int discountPercentage = 10;
        public double CalculateDiscount(double deliveryCost)
        {
            return (deliveryCost * discountPercentage) / 100;
        }

        public bool IsApplicable(Package package)
        {
            return package.Distance < 200 && (package.Weight >= 70 && package.Weight <= 200);
        }
    }
}
