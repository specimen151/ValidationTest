using Funq;
using ServiceStack.Text;
using ValidationTest.Services;

[assembly: HostingStartup(typeof(ValidationTest.AppHost))]

namespace ValidationTest;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
        => builder        
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("ValidationTest", typeof(TestService).Assembly) {}

    public override void Configure(Container container)
    {
        // enable server-side rendering, see: https://sharpscript.net/docs/sharp-pages
        Plugins.Add(new SharpPagesFeature {
            EnableSpaFallback = true
        });

        Plugins.Add(new CorsFeature(
            allowCredentials: true,
            allowOriginWhitelist: new[]
            {
                "http://127.0.0.1:5173"
            }
        ));

        //var feature = Plugins.FirstOrDefault(x => x is ValidationFeature) as ValidationFeature;
        //if (feature != null) {
        //    feature.ImplicitlyValidateChildProperties = true;
        //}

        SetConfig(new HostConfig
        {
            AddRedirectParamsToQueryString = true,
        });

        JsConfig.Init(new Config
        {
            DateHandler = DateHandler.ISO8601,
            AlwaysUseUtc = false,
            TextCase = TextCase.CamelCase,
            ExcludeDefaultValues = false,        // e.g. IsStartupItem=false won't be emitted unless ==true
            IncludeNullValues = false
        });
    }
}
