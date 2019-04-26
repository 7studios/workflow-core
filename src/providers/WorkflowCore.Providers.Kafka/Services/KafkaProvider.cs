using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Models.LifeCycleEvents;

using Silverback.Messaging;
using Silverback;
using Silverback.Messaging.Messages;
using Silverback.Messaging.Proxies;
using Silverback.Messaging.Broker;
using System.Threading;
using Silverback.Messaging.Subscribers;
using WorkflowCore.Providers.Kafka.Interface;

namespace WorkflowCore.Providers.Kafka.Services
{

    public class KafkaProvider : ILifeCycleEventHub
    {
        private readonly ILogger _logger;

        private readonly string _streamName;
        private readonly string _appName;

        private readonly MessageKeyProvider _messageKeyProvider;
        private readonly KafkaBroker _broker;
        private readonly KafkaConsumerConfig _config;

        private IConsumer _consumer;



        public KafkaProvider(string boostrapservers, string groupId, ILoggerFactory logFactory)
        {
            _messageKeyProvider = new MessageKeyProvider(new[] { new DefaultPropertiesMessageKeyProvider() });
            _broker = new KafkaBroker(_messageKeyProvider, logFactory, new MessageLogger(_messageKeyProvider));

            _config = new KafkaConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = boostrapservers,
                AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest,
                SessionTimeoutMs = 6000,
                EnablePartitionEof = true
            };
        }

        public Task Start()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }

        public Task PublishNotification(LifeCycleEvent evt)
        {
            throw new NotImplementedException();
        }

        public void Subscribe(Action<LifeCycleEvent> action)
        {
            _consumer = _broker.GetConsumer(new KafkaConsumerEndpoint("Topic1"));
            _broker.Connect();
        }
    }

}
