using CourierService.Application.Interfaces.Pricing;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Services.Pricing
{
    public class DeliveryCostCalculator : IDeliveryCostCalculator
    {
        public double CalculatePackageCost(Package package, int baseCost)
        {
            return baseCost + (package.Weight * 10) + (package.Distance * 5);
        }
    }
}
