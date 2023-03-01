using FluentValidation;
using PracticumFinalCase.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.ShoppingList.UpdateShoppingList
{
    public class UpdateShoppingListCommandRequestValidator : AbstractValidator<UpdateShoppingListCommandRequest>
    {
        public UpdateShoppingListCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Title).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Dto.CategoryName).Must(x => Category.Categories.Contains(x));
        }
    }
}
