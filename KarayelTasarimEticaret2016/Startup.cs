using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KarayelTasarimEticaret2016.Startup))]
namespace KarayelTasarimEticaret2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
