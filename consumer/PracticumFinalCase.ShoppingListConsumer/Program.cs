using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;
using System.Text;

namespace PracticumFinalCase.ShoppingListConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Redis Db connection
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("localhost");
            IDatabase database = conn.GetDatabase();
            var redisOperations = new RedisDbOperations(database);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = JsonConvert.DeserializeObject<ShoppingListModel>(Encoding.UTF8.GetString(body));

                    redisOperations.AddShoppingListToDb(message);
                    Console.WriteLine("Completed shopping list recieved and writed to redis db.");
                };
                channel.BasicConsume(queue: "ShoppingListsQueue", //Kuyruk adı
                    autoAck: true, //Kuyruk adı doğrulanması
                    consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}