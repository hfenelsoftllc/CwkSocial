namespace CwkSocial.Api.Registers
{
    public interface IWebApplicationRegister: IRegister
    {
        public void RegisterPipelineComponents(WebApplication webApplication);
    }
}
