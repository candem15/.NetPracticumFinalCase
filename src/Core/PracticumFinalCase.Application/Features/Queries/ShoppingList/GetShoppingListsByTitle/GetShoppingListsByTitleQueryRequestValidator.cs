using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByTitle
{
    public class GetShoppingListsByTitleQueryRequestValidator : AbstractValidator<GetShoppingListsByTitleQueryRequest>
    {
        public GetShoppingListsByTitleQueryRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
