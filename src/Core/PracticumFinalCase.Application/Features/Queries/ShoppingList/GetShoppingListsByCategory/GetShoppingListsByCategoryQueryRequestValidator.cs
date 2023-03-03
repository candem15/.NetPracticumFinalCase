using FluentValidation;
using PracticumFinalCase.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCategory
{
    public class GetShoppingListsByCategoryQueryRequestValidator : AbstractValidator<GetShoppingListsByCategoryQueryRequest>
    {
        public GetShoppingListsByCategoryQueryRequestValidator()
        {
            RuleFor(x => x.CategoryName).Must(x => Category.Categories.Contains(x)).WithMessage("Given category is not exists!");
        }
    }
}
