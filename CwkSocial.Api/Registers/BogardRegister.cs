using CkwSocial.Application.UserProfiles.Queries;
using MediatR;

namespace CwkSocial.Api.Registers
{
    // Create to honor the creator of Mediator and automapper
    public class BogardRegister : IWebApplicationBuilderRegister
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfiles));
            builder.Services.AddMediatR(typeof(GetAllUserProfiles));
        }
    }
}
