using FluentValidation;
using PracticumFinalCase.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequestValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Dto.Price).NotEmpty();
            RuleFor(x => x.Dto.Description).NotEmpty();
            RuleFor(x => x.Dto.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Dto.Measurement).Must(x => Measurement.Measurements.Contains(x));
        }
    }
}
