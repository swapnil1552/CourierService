using CourierService.Application.Interfaces.Delivery;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CourierService.Application.Services.Delivery
{
    public class ShipmentBuilder : IShipmentBuilder
    {
        private Shipment _bestShipment;
        public Shipment GetShipment(List<Package> availablePackages, double maxVehicleWeight)
        {
            _bestShipment = new Shipment();
            BuildRecursive(availablePackages, 0, new Shipment(), maxVehicleWeight);
            return _bestShipment;
        }

        private void BuildRecursive(List<Package> packages, int index, Shipment current, double maxWeight)
        {
            //stop if the weight exceeds the limit
            if (current.TotalWeight > maxWeight)
                return;

            if(IsBestShipment(current, _bestShipment))
            {
                _bestShipment = Clone(current);
            }

            for(int i = index; i < packages.Count; i++)
            {
                current.AddPackage(packages[i]);
                BuildRecursive(packages, i + 1, current, maxWeight);
                current.RemoveLastPackage();
            }
        }

        private bool IsBestShipment(Shipment current, Shipment best)
        {
            if(!current.Packages.Any())
                return false;

            if(current.Packages.Count > best.Packages.Count)
                return true;
            if (current.Packages.Count == best.Packages.Count && current.TotalWeight > best.TotalWeight)
                return true;

            if (current.Packages.Count == best.Packages.Count && current.TotalWeight == best.TotalWeight && current.MaxDistance < best.MaxDistance)
                return true;

            return false;

        }

        private Shipment Clone(Shipment shipment)
        {
            var clone = new Shipment();
            foreach(var package in shipment.Packages)
            {
                clone.AddPackage(package);
            }

            return clone;
        }
    }
}
