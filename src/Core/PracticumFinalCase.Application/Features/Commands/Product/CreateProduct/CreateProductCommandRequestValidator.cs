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
            RuleFor(x => x.dto.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.dto.Price).NotEmpty();
            RuleFor(x => x.dto.Description).NotEmpty();
            RuleFor(x => x.dto.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.dto.Measurement).Must(x => Measurement.Measurements.Contains(x));
        }
    }
}
