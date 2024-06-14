using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class DependencyRegistration
    {
        public static IServiceProvider Register()
        {
            var services = new ServiceCollection();

            services.AddScoped<App>();
            BLL.DependencyRegistration.RegisterServices(services);

            return services.BuildServiceProvider();
        }
    }
}
