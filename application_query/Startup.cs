using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(application_query.Startup))]
namespace application_query
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
