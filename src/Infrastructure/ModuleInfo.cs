using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class ModuleInfo : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((config, services) => { services.AddDbContext<OrderingDbContext>(); });
    }
}