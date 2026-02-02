using CourierService.Application.Interfaces.Offers;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Infrastructure.Offers
{
    public class OfferOFR002 : IOffer
    {
        private readonly int discountPercentage = 7;

        public string OfferCode => "OFR002";

        public double CalculateDiscount(double deliveryCost)
        {
            return (deliveryCost * discountPercentage) / 100;
        }

        public bool IsApplicable(Package package)
        {
            return (package.Distance >=50 && package.Distance <= 150) && (package.Weight >= 100 && package.Weight <= 250);
        }
    }
}
