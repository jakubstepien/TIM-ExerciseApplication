using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcerciseApp.Startup))]
namespace ExcerciseApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
