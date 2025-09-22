using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application
{
   static public class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }
}
