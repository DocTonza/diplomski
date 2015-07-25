using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TonzaDiplomski.Startup))]
namespace TonzaDiplomski
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
