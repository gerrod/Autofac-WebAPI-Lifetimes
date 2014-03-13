#region Using directives

using Autofac;
using Newtonsoft.Json;

#endregion


namespace DecompileIt.Autofac.Resolvables
{
    public class ResolvableConsumer
    {
        private readonly PerDependencyResolvable _dependency;
        private readonly PerLifetimeResolvable _lifetime;
        private readonly PerRequestResolvable _request;
        private readonly SingletonResolvable _singleton;

        public ResolvableConsumer(SingletonResolvable singleton, PerLifetimeResolvable lifetime, PerRequestResolvable request, PerDependencyResolvable dependency)
        {
            _singleton = singleton;
            _lifetime = lifetime;
            _request = request;
            _dependency = dependency;
        }

        public string A_Singleton
        {
            get { return _singleton.Description; }
        }

        public string B_Lifetime
        {
            get { return _lifetime.Description; }
        }

        public string C_Request
        {
            get { return _request.Description; }
        }

        public string D_Dependency
        {
            get { return _dependency.Description; }
        }

        public string E_ActiveTokens 
        {
            get { return ScopeToken.ActiveTokens; }
        }
    }
}