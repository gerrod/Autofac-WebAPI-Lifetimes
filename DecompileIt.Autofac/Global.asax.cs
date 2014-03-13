#region Using directives

using System.Web;
using System.Web.Http;
using Autofac;
using DecompileIt.Autofac.Resolvables;

#endregion


namespace DecompileIt.Autofac
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            IoC.BuildContainer();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}