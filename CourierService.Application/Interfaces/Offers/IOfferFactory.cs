using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Interfaces.Offers
{
    public interface IOfferFactory
    {
        IOffer GetOffer(string offerCode);
    }
}
