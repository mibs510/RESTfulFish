using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RESTfulFish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Still need to determine if this is a good viable option
             * CreateHostBuilder(args).Build().Run();
             */
            Misc misc = new Misc();

            Misc.LogInRESTfulFish();

            // RESTfulFish needs to be logged into Fishbowl server indefinitely, so start a second and third thread.
            // This needs to come after logging into Fishbowl.
            ThreadStart KeepAliveRef = new ThreadStart(misc.KeepAlive);
            Thread KeepAliveThread = new Thread(KeepAliveRef);
            KeepAliveThread.Start();
            ThreadStart WatchDogtRef = new ThreadStart(misc.WatchDog);
            Thread WatchDogThread = new Thread(WatchDogtRef);
            WatchDogThread.Start();

            // Let the fish eat grapes! (start Grapevine REST HTTP server)
            ThreadStart GrapeRef = new ThreadStart(Grapes.StartGrapevineServer);
            Thread GrapeThread = new Thread(GrapeRef);
            GrapeThread.Start();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
