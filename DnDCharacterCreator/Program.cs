using Microsoft.Extensions.DependencyInjection;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = DependencyRegistration.Register();
            var app = serviceProvider.GetRequiredService<App>();
            while (true)
            {
                app.Run();
            }
        }
    }
}
