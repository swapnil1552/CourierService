using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Domain.Enities;

namespace CourierService.Application.Interfaces.Offers
{
    public interface IOffer
    {
        public string OfferCode { get; }
        public bool IsApplicable(Package package);
        public double CalculateDiscount(double deliveryCost);
    }
}
