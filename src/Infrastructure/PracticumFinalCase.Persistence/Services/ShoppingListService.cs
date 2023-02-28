using AutoMapper;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Abstractions.UnitOfWork;
using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.Domain.Models;
using Serilog;

namespace PracticumFinalCase.Persistence.Services
{
    public class ShoppingListService : BaseService<ShoppingListDto, ShoppingList>, IShoppingListService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ShoppingListService(IGenericRepository<ShoppingList> genericRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(genericRepository, mapper, unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<ShoppingListDto>>> GetShoppingListsByTitle(string title)
        {
            var result = await unitOfWork.ShoppingListRepository.GetWhereAsync(x => x.Title == title);

            if (!result.Any())
                return new BaseResponse<IEnumerable<ShoppingListDto>>("Shopping lists with given title not exists.");

            var mapped = mapper.Map<IEnumerable<ShoppingListDto>>(result);

            return new BaseResponse<IEnumerable<ShoppingListDto>>(mapped);
        }
    }
}
