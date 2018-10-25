using SIS.Framework.Api.Contracts;
using SIS.Framework.Services;
using SIS.Framework.Services.Contracts;

namespace MishMashWebApp
{
    public class StartUp : IMvcApplication
    {
        public void Configure()
        {
        }

        public void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUserCookieService, UserCookieService>();
            //dependencyContainer.CreateInstance()
        }
    }
}