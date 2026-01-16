using CourierService.Application.Interfaces.Delivery;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Services.Delivery
{
    public class DeliveryScheduler : IDeliveryScheduler
    {
        private readonly IShipmentBuilder _shipmentBuilder;
        public DeliveryScheduler(IShipmentBuilder shipmentBuilder) 
        {
            _shipmentBuilder = shipmentBuilder;
        
        }
        public void Schedule(List<Package> packages, List<Vehicle> vehicles)
        {
            var remainingPackages = new List<Package>(packages);

            while (remainingPackages.Any())
            {
                var vehicle = vehicles.OrderBy(v => v.AvailableAt).First();
                double tripStartTime = vehicle.AvailableAt;
                double maxEstimatedDeliveryTime = 0;

                var shipment = _shipmentBuilder.GetShipment(remainingPackages, vehicle.MaxWeight);

               foreach (var package in shipment.Packages)
               {
                    var estimatedDeliveryTimePerPkg = Math.Truncate((package.Distance / vehicle.Speed) * 100) / 100;
                    if (estimatedDeliveryTimePerPkg > maxEstimatedDeliveryTime)
                    {
                        maxEstimatedDeliveryTime = estimatedDeliveryTimePerPkg;
                    }
                    package.EstimatedDeliveryTime = Math.Truncate((tripStartTime + estimatedDeliveryTimePerPkg) * 100) / 100;
               }

               vehicle.AvailableAt = tripStartTime + (2 * maxEstimatedDeliveryTime);
               
               foreach (var package in shipment.Packages)
               {
                    remainingPackages.Remove(package);
               }
            }
        }
    }
}
