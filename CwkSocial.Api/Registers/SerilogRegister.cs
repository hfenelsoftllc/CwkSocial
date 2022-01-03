using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace CwkSocial.Api.Registers
{
    public class SerilogRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Host
                .UseSerilog((context, configuration) =>
                    {
                        configuration
                         .Enrich.FromLogContext()
                         .Enrich.WithMachineName()
                         //.WriteTo.Async(wt => wt.Console())
                         .WriteTo.Console()
                         .WriteTo.Elasticsearch(
                            new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                            {
                                IndexFormat = $"applogs-{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".","-")}-logs-{DateTime.UtcNow:yyyy-MM}",
                                AutoRegisterTemplate = true,
                                NumberOfShards = 2,
                                NumberOfReplicas = 1,
                            })
                         .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                         .ReadFrom.Configuration(context.Configuration);
                    });
                //.ConfigureWebHostDefaults(webBuilder =>
                //    {
                //        webBuilder.UseStartup<Program>();
                //    });
        }
    }
}
 