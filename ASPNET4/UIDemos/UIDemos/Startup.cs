using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIDemos.Startup))]
namespace UIDemos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
