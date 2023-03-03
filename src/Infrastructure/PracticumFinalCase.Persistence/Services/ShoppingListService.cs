using AutoMapper;
using Newtonsoft.Json;
using PracticumFinalCase.Application.Abstractions.RabbitMq;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;
using Serilog;
using StackExchange.Redis;
using System.Linq;

namespace PracticumFinalCase.Persistence.Services
{
    public class ShoppingListService : BaseService<Object, ShoppingList>, IShoppingListService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRabbitMqProducer rabbitMqProducer;
        private readonly ConnectionMultiplexer connection;

        public ShoppingListService(IGenericRepository<ShoppingList> genericRepository, IMapper mapper, IUnitOfWork unitOfWork, IRabbitMqProducer rabbitMqProducer, ConnectionMultiplexer connection) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.rabbitMqProducer = rabbitMqProducer;
            this.connection = connection;
        }

        public async Task<BaseResponse<object>> CompleteAsync(int id)
        {
            try
            {
                unitOfWork.ShoppingListRepository.CompleteAsync(id);
                await unitOfWork.CompleteAsync();
                Log.Information($"Completion done for shopping list with id: {id}");

                ShoppingList shoppingListToSend = await unitOfWork.ShoppingListRepository.GetByIdAsync(id);

                var mapped = mapper.Map<ShoppingListEventDto>(shoppingListToSend);

                rabbitMqProducer.SendShoppingListToQueueEvent(mapped);

                return new BaseResponse<object>(true);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message} error occurred at completion of shopping list with id: {id}");
                return new BaseResponse<object>("CompletionError");
            }
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByTitle(string title)
        {
            var result = await unitOfWork.ShoppingListRepository.GetWhereAsync(x => x.Title == title);

            if (!result.Any())
                return new BaseResponse<IEnumerable<ShoppingListDto>>("Shopping lists with given title not exists.");

            var mapped = mapper.Map<IEnumerable<ShoppingListDto>>(result);

            return new BaseResponse<IEnumerable<ShoppingListDto>>(mapped);
        }

        public async Task<BaseResponse<ShoppingListDto>> InsertWithOwnerAsync(CreateShoppingListDto insertResource, int ownerId)
        {
            ShoppingList newList = new();
            newList.CreatedAt = DateTime.Now;
            newList.UpdatedAt = DateTime.Now;
            newList.Title = insertResource.Title;
            newList.UserId = ownerId;
            newList.CategoryName = insertResource.CategoryName;
            await unitOfWork.ShoppingListRepository.InsertAsync(newList);
            await unitOfWork.CompleteAsync();
            Log.Information($"New shopping list created for owner with OwnerId : {ownerId}");
            return new BaseResponse<ShoppingListDto>(true);
        }

        public override async Task<BaseResponse<IEnumerable<object>>> GetAllAsync()
        {
            try
            {
                var server = connection.GetServer(connection.GetEndPoints().First());

                var keys = server.Keys().Where(x => int.TryParse(x, out int number) == true).Select(key => (string)key).ToList();

                IDatabase redisDb = connection.GetDatabase();

                List<ShoppingListEventDto> shoppingLists = new();
                foreach (string key in keys)
                {
                    shoppingLists.Add(JsonConvert.DeserializeObject<ShoppingListEventDto>(redisDb.StringGet(key)));
                }

                return new BaseResponse<IEnumerable<object>>(shoppingLists);
            }
            catch (Exception ex)
            {
                Log.Error("Error occured while getting shopping lists from redis db.");

                return new BaseResponse<IEnumerable<object>>(false);
            }

        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByCategory(string categoryName)
        {
            var result = await unitOfWork.ShoppingListRepository.GetWhereAsync(x => x.CategoryName == categoryName);

            if (result == null)
                return new BaseResponse<IEnumerable<ShoppingListDto>>("No list exists with given category.");

            var mapped = mapper.Map<IEnumerable<ShoppingListDto>>(result);

            return new BaseResponse<IEnumerable<ShoppingListDto>>(mapped);
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetByCreateDateAsync(string createDate)
        {


            var result = await unitOfWork.ShoppingListRepository.GetWhereAsync(x => x.CreatedAt.Date == DateTime.Parse(createDate).Date);

            if (result == null)
                return new BaseResponse<IEnumerable<ShoppingListDto>>("No list created at given date.");

            var mapped = mapper.Map<IEnumerable<ShoppingListDto>>(result);

            return new BaseResponse<IEnumerable<ShoppingListDto>>(mapped);
        }
    }
}
