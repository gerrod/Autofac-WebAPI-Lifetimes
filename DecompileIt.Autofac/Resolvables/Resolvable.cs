using System;

namespace DecompileIt.Autofac.Resolvables
{
    public abstract class Resolvable
    {
        private readonly ScopeToken _token;

        protected Resolvable(ScopeToken token)
        {
            _token = token;
            token.AddResolver(GetType().Name.Replace("Resolvable", String.Empty));
        }

        public virtual string Description 
        {
            get { return String.Format("{0} references {1}", GetType().Name, _token); }
        }
    }
}