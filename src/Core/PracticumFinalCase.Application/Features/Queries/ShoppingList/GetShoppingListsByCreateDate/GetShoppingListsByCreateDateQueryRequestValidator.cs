using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Queries.ShoppingList.GetShoppingListsByCreateDate
{
    public class GetShoppingListsByCreateDateQueryRequestValidator : AbstractValidator<GetShoppingListsByCreateDateQueryRequest>
    {
        public GetShoppingListsByCreateDateQueryRequestValidator()
        {

            RuleFor(x => x.Date).NotEmpty().Must(x => BeAValidDate(x)).WithMessage("Invalid date entered.");
        }
        private bool BeAValidDate(string date)
        {
            try
            {
                var check = DateTime.Parse(date);
                if (check == default(DateTime) || check > DateTime.Now)
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

