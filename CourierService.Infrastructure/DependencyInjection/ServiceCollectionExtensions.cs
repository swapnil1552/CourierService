using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierService.Application.Interfaces.Delivery;
using CourierService.Application.Interfaces.Offers;
using CourierService.Application.Interfaces.Pricing;
using CourierService.Application.Services;
using CourierService.Application.Services.Delivery;
using CourierService.Application.Services.Pricing;
using CourierService.Infrastructure.Factories;
using CourierService.Infrastructure.Input;
using CourierService.Infrastructure.Offers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CourierService.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCourierServices(this IServiceCollection services)
        {
            //pricing
            services.AddSingleton<IDeliveryCostCalculator, DeliveryCostCalculator>();
            services.AddSingleton<IDiscountService, DiscountService>();

            //Delivery
            services.AddSingleton<IDeliveryScheduler, DeliveryScheduler>();
            services.AddSingleton<IShipmentBuilder, ShipmentBuilder>();

            //offer factory
            services.AddSingleton<IOfferFactory, OfferFactory>();

            //offer Stratergies
            services.AddSingleton<IOffer, OfferOFR001>();
            services.AddSingleton<IOffer, OfferOFR002>();
            services.AddSingleton<IOffer, OfferOFR003>();

            services.AddSingleton<CourierServiceProcessor>();

            services.AddSingleton<ConsoleInputService>();

            return services;
        }
    }
}
