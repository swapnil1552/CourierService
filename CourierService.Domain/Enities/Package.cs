using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Domain.Enities
{
    public class Package
    {
        public string Id;
        public double Weight;
        public double Distance;
        public string OfferCode;
        public double Discount;
        public double TotalCost;
        public double EstimatedDeliveryTime;
    }
}
