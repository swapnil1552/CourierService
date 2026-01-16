using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Interfaces.Delivery
{
    public interface IDeliveryScheduler
    {
        public void Schedule(List<Package> packages, List<Vehicle> vehicle);
    }
}
