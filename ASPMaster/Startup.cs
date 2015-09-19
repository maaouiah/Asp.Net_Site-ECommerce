using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPMaster.Startup))]
namespace ASPMaster
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
