using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Makaretu.Dns;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PrivateHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceName = "privatehome.local";
            var mdns = new MulticastService();
            mdns.QueryReceived += (s, e) =>
            {
                var msg = e.Message;
                var question = msg.Questions.FirstOrDefault();
                var isEqual = question.Name == serviceName;
                if (msg.Questions.Any(q => q.Name == serviceName))
                {
                    Console.WriteLine("Received local host lookup question.");

                    var res = msg.CreateResponse();
                    var allAddresses = MulticastService.GetIPAddresses();
                    var ipv4Addresses = allAddresses
                        .Where(ip => ip.AddressFamily == AddressFamily.InterNetwork
                        && ip.ToString().StartsWith("192."));

                    foreach (var address in ipv4Addresses)
                    {
                        res.Answers.Add(new ARecord
                        {
                            Name = serviceName,
                            Address = address
                        });
                    }

                    var ipv6Addresses = allAddresses
                        .Where(ip => ip.AddressFamily == AddressFamily.InterNetworkV6
                        && ip.ToString().StartsWith("fe80::"));
                    foreach (var address in ipv6Addresses)
                    {
                        res.Answers.Add(new AAAARecord
                        {
                            Name = serviceName,
                            Address = address
                        });
                    }

                    mdns.SendAnswer(res);
                }
            };
            mdns.Start();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:80", "https://*:443");
                });
    }
}
