using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TI2Project.Startup))]
namespace TI2Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
