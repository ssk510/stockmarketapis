using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Kafka;
using Company.API.Logging;

namespace Company.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 //.WriteTo.Kafka(bootstrapServers: "localhost:9092", topic: "company", securityProtocol: Confluent.Kafka.SecurityProtocol.Plaintext)
                 .WriteTo.File(@"C:\\Estockmarket_company_api.txt")
                 .Enrich.CompanyLogEnricher()
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
