using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProcessaNotificacao
{
    public class ProcessaFilaAzureServiceBus
    {
        private readonly ILogger<ProcessaFilaAzureServiceBus> _logger;

        public ProcessaFilaAzureServiceBus(ILogger<ProcessaFilaAzureServiceBus> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ProcessaFilaAzureServiceBus))]
        public void Run([ServiceBusTrigger("notification", Connection = "ServicebusConnectionString")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
