using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoContacts.Startup))]
namespace GoContacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
