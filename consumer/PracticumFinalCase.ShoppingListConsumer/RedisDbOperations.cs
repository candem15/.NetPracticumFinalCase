using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.ShoppingListConsumer
{
    public class RedisDbOperations
    {
        private readonly IDatabase database;

        public RedisDbOperations(IDatabase database)
        {
            this.database = database;
        }

        public void AddShoppingListToDb(ShoppingListModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            //set value in redis db
            database.StringSet("#" + model.Id.ToString(), json);
        }
    }
}
