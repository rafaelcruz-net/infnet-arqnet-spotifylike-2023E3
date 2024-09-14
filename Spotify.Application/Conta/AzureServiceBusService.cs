using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spotify.Application.Conta
{
    public class AzureServiceBusService
    {
        private string ConnectionString;

        public AzureServiceBusService(IConfiguration configuration)
        {
            this.ConnectionString = configuration["AzureServiceBus:ConnectionString"];
        }

        public async Task SendMessage(Notificacao notificacao)
        {
            ServiceBusClient client;
            ServiceBusSender sender;

            client = new ServiceBusClient(this.ConnectionString);

            sender = client.CreateSender("notification");

            var body = JsonSerializer.Serialize(notificacao);

            var message = new ServiceBusMessage(body);

            await sender.SendMessageAsync(message); 
        }
    }
}
