using CwkSocial.Dal;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Api.Registers
{
    public class DbRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //var conn = builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            ////var database = builder.Configuration.GetValue<string>("DatabaseSettings:DatabaseName");
            //builder.Services.AddDbContext<DataContext>(Options =>
            //{
            //    Options.UseSqlServer(conn);                
            //});

            var cs = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(cs, b =>b.MigrationsAssembly("CwkSocial.Api"));
            });
        }
    }
}
