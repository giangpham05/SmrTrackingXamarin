using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMR.Tracking.DataAccess;
using System;

namespace SMR.Tracking.DesignTime
{
    class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
                .ConfigureServices(services => services.AddScoped(_ => new CloudDbContext("Server=GPHAM-HOME;Database=TrackingDb;Trusted_Connection=True;")));
        }
    }
}
