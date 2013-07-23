using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.Configuration;

namespace AI.nRepo
{
    public interface InRepoConfiguration
    {
        InRepoConfiguration With(string alias, IRepositoryConfiguration configuration);
        IRepositoryConfiguration GetConfiguration(string alias);
        InRepoConfiguration WithEvent(IRepositoryEvent @event);
        void Start();
    }

    public class nRepoConfiguration : InRepoConfiguration
    {
        public InRepoConfiguration With(string alias, IRepositoryConfiguration configuration)
        {
            _configurations[alias] = configuration;
            return this;
        }

        private static Dictionary<string, IRepositoryConfiguration> _configurations = new Dictionary<string, IRepositoryConfiguration>();

        public IRepositoryConfiguration GetConfiguration(string alias)
        {
            if (_configurations.ContainsKey(alias))
                return _configurations[alias];
            return null;
        }

        public InRepoConfiguration WithEvent(IRepositoryEvent @event)
        {
            RepositoryEventRegistry.Register(@event);
            return this;
        }

        public void Start()
        {
            foreach (var kvp in _configurations)
            {
                kvp.Value.Start();
            }
        }
    }
}
