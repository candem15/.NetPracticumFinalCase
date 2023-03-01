using PracticumFinalCase.Application.Dtos.ShoppingList;
using PracticumFinalCase.Application.Response;

namespace PracticumFinalCase.Application.Abstractions.Services
{
    public interface IBaseService<Dto, Entity>
    {
        Task<BaseResponse<Dto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<BaseResponse<Dto>> InsertAsync(Dto insertResource);
        Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource);
        Task<BaseResponse<Dto>> RemoveAsync(int id);
    }
}
