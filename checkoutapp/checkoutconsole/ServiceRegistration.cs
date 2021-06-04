using checkoutconsole.Common.Interfaces;
using checkoutconsole.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkoutconsole
{
    public class ServiceRegistration
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IPromotionEngine, PromotionEngine>();
            services.AddSingleton<IDataLoader, FileLoader>();
            services.AddTransient<ICheckoutService, CheckoutService>();
        }
    }
}
