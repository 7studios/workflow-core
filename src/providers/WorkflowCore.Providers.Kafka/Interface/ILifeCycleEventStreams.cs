using System;
using System.Threading.Tasks;
using WorkflowCore.Models.LifeCycleEvents;

namespace WorkflowCore.Providers.Kafka.Interface
{
    public interface ILifeCycleEventStreams
    {
        Task PublishAsync(LifeCycleEvent evt);
        Task SubscribeAsync(Action<LifeCycleEvent> action);

        Task Start();
        Task Stop();
    }
}
