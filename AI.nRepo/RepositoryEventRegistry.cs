using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo
{
    public static class RepositoryEventRegistry
    {
        private static IList<IRepositoryEvent> _events = new List<IRepositoryEvent>();

        public static void Register(IRepositoryEvent @event)
        {
            _events.Add(@event);
        }

        public static void RaiseEvent<T>(object entity)
            where T : class, IRepositoryEvent
        {
            foreach (var eventHandler in _events)
            {
                var handler = eventHandler as T;
                if(handler != null)
                {
                    handler.Handle(entity);
                }

            }
        }
    }
}
