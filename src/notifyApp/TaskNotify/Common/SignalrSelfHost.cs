using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: OwinStartup(typeof(TaskNotify.Common.StartUp))]
namespace TaskNotify.Common
{
    class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    public class SignalrSelfHost : IDisposable
    {
        private IDisposable server = null;
        public static string HostUrl { get { return string.Format(HostUrlStr, Properties.Settings.Default.ServerPort); } }

        public static string HostUrlStr = "http://localhost:{0}/";

        public void Dispose()
        {
            this.Stop();
        }

        public void Start()
        {
            server = WebApp.Start(HostUrl);
        }

        public void Stop()
        {
            if (server != null)
            {
                try
                {
                    server.Dispose();
                }
                catch { }
            }
        }

    }
}
