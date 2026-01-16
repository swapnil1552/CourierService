using CourierService.Application.Interfaces.Offers;
using CourierService.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Interfaces.Pricing
{
    public interface IDiscountService
    {
        public double Apply(Package package, double delivertCost);
    }
}
