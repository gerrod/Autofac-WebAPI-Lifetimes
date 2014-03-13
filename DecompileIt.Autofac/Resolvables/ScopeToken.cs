#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

#endregion


namespace DecompileIt.Autofac.Resolvables
{
    public class ScopeToken
    {
        private static int _instanceId;
        private static readonly IList<ScopeToken> _activeTokens = new List<ScopeToken>();
        
        private readonly int _id;
        private readonly IList<string> _resolutionHistory = new List<string>(4);

        public ScopeToken(ILifetimeScope scope)
        {
            _id = ++_instanceId;
            ScopeName = Convert.ToString(scope.Tag);

            _activeTokens.Add(this);
            scope.CurrentScopeEnding += (sender, args) => _activeTokens.Remove(this);
        }

        public int Id
        {
            get { return _id; }
        }

        public string ScopeName { get; private set; }

        public void AddResolver(string resolver)
        {
            _resolutionHistory.Add(resolver);
        }

        public override string ToString()
        {
            return String.Format("Token #{0} from scope '{1}'", Id, ScopeName);
        }

        public static string ActiveTokens
        {
            get
            {
                var tokens =
                    from token in _activeTokens
                    select String.Format("Token #{0} referenced by: {1}", token.Id, String.Join(", ", token._resolutionHistory));

                return String.Join("; ", tokens);
            }
        }
    }
}