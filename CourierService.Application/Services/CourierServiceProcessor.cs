using CourierService.Application.Interfaces.Delivery;
using CourierService.Application.Interfaces.Pricing;
using CourierService.Application.Services.Pricing;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Services
{
    public class CourierServiceProcessor
    {
        private readonly IDeliveryCostCalculator _deliveryCostCalculator;
        private readonly IDeliveryScheduler _deliveryScheduler;
        private readonly IDiscountService _discountService;
        public CourierServiceProcessor(IDiscountService discountService, IDeliveryCostCalculator deliveryCostCalculator, IDeliveryScheduler deliveryScheduler)
        {
            _discountService = discountService;
            _deliveryCostCalculator = deliveryCostCalculator;
            _deliveryScheduler = deliveryScheduler;
        }

        public void Process(List<Package> packages, List<Vehicle> vehicles, int baseDeliveryCost)
        {
            foreach (Package package in packages)
            {
                var deliveryCost = _deliveryCostCalculator.CalculatePackageCost(package, baseDeliveryCost);
                package.Discount = _discountService.Apply(package, deliveryCost);
                package.TotalCost = deliveryCost - package.Discount;
            }

            _deliveryScheduler.Schedule(packages, vehicles);
            
        }
    }
}
