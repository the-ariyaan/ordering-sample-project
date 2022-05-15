using Microsoft.AspNetCore.Hosting;

namespace Domain;

public class ModuleInfo : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((config, services) => { });
    }
}