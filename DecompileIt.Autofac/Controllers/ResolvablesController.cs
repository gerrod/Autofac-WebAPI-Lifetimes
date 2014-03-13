#region Using directives

using System.Web.Http;
using Autofac.Integration.WebApi;
using DecompileIt.Autofac.Resolvables;

#endregion


namespace DecompileIt.Autofac.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        private readonly ResolvableConsumer _consumer;

        public TestController(ResolvableConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET api/values
        [HttpGet]
        [Route("")]
        public ResolvableConsumer Get()
        {
            return _consumer;
        }
    }
}
