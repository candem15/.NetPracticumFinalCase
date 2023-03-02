using PracticumFinalCase.Application.Dtos.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Abstractions.RabbitMq
{
    public interface IRabbitMqProducer
    {
        void SendShoppingListToQueueEvent(ShoppingListEventDto dto);
    }
}
