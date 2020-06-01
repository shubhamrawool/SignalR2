using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunChat.Startup))]
namespace FunChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
