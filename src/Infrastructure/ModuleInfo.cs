using Microsoft.AspNetCore.Hosting;

namespace Infrastructure;

public class ModuleInfo : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((config, services) => { });
    }
}