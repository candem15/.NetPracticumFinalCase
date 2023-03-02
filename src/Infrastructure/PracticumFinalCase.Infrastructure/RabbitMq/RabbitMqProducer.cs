using Newtonsoft.Json;
using PracticumFinalCase.Application.Abstractions.RabbitMq;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using RabbitMQ.Client;
using System.Text;

namespace PracticumFinalCase.Infrastructure.RabbitMq
{
    public class RabbitMqProducer : IRabbitMqProducer
    {
        public void SendShoppingListToQueueEvent(ShoppingListEventDto dto)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };//Konfigurasyondan alınabilir            
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ShoppingListsQueue",
                    durable: true, //Data saklama yöntemi (memory-fiziksel)
                    exclusive: false, //Başka bağlantıların kuyruğa ulaşmasını istersek true kullanabiliriz.
                    autoDelete: false,
                    arguments: null);//Exchange parametre tanımları.          

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto)); // Dto yu serialize ederek body'e veriyoruz.

                channel.BasicPublish(exchange: "",
                    routingKey: "ShoppingListsQueue",
                    body: body);
            }
        }
    }
}
