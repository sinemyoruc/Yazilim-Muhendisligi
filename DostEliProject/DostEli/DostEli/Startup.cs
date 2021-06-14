using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(DostEli.Startup))]
namespace DostEli
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
