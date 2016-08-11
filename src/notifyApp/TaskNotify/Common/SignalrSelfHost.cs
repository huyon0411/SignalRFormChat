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
    /// <summary>
    /// Owin StartUp Class
    /// SignalR Setting only.
    /// </summary>
    class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

    /// <summary>
    /// SignalR SelfHost Server 
    /// </summary>
    public class SignalrSelfHost : IDisposable
    {
        /// <summary>
        /// Owin WebApp Server.
        /// </summary>
        private IDisposable server = null;

        /// <summary>
        /// HostUrl read Properties.Settings.Default.ServerPort.
        /// </summary>
        public static string HostUrl { get { return string.Format(HostUrlStr, Properties.Settings.Default.ServerPort); } }

        /// <summary>
        /// HostUrl Template
        /// </summary>
        public static string HostUrlStr = "http://+:{0}/";

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Stop();
        }

        /// <summary>
        /// Start The Server
        /// </summary>
        public void Start()
        {
            this.WriteTrace("Start Server URL:" + HostUrl);
            server = WebApp.Start(HostUrl);
        }

        /// <summary>
        /// Stop The Server
        /// </summary>
        public void Stop()
        {
            if (server != null)
            {
                try
                {
                    server.Dispose();
                }
                catch { }
                this.WriteTrace("Stop Server URL:" + HostUrl);
            }
        }
    }
}
