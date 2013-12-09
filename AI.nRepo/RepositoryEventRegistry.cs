using AI.nRepo.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo
{
    public static class RepositoryEventRegistry
    {
        private static IList<IRepositoryEvent> _events = new List<IRepositoryEvent>();

        private static IList<IQueryInterceptor> _interceptors = new List<IQueryInterceptor>();

        public static void Register(IRepositoryEvent @event)
        {
            _events.Add(@event);
        }

        public static void Register(IQueryInterceptor interceptor)
        {
            _interceptors.Add(interceptor);
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

        public static IEnumerable<IQueryInterceptor> GetQueryInterceptors<T>()
        {
            foreach (var eventHandler in _interceptors)
            {
                if (eventHandler.CanHandle<T>())
                    yield return eventHandler;
            }
            yield break;
        }
    }
}
