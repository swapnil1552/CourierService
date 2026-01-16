using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Domain.Enities
{
    public class Shipment
    {
        private readonly List<Package> _packages = new();

        public IReadOnlyList<Package> Packages => _packages;
        public double TotalWeight => _packages.Sum(p => p.Weight);
        public double MaxDistance => _packages.Any() ? _packages.Sum(p => p.Distance) : 0;

        public void AddPackage(Package package)
        {
            _packages.Add(package);
        }

        public void RemoveLastPackage()
        {
            if(_packages.Any())
                _packages.RemoveAt(_packages.Count - 1);
        }
    }
}
