#region Using directives

using System.Web.Http;
using Autofac.Integration.WebApi;
using DecompileIt.Autofac.Resolvables;

#endregion


namespace DecompileIt.Autofac.Controllers
{
    [RoutePrefix("dude")]
    public class DudeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "the dude";
        }
    }
}
