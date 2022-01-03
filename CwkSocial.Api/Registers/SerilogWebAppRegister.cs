using Serilog;

namespace CwkSocial.Api.Registers
{
    public class SerilogWebAppRegister : IWebApplicationRegister
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            app.UseSerilogRequestLogging();
           
        }
    }
}
