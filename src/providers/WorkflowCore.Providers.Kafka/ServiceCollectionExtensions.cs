using System;
using WorkflowCore.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static WorkflowOptions UseKafka(this WorkflowOptions options)
        {
            return options;
        }
    }
}