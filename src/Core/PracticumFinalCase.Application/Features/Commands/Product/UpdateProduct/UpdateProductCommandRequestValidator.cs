using FluentValidation;
using PracticumFinalCase.Domain.Types;

namespace PracticumFinalCase.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequestValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandRequestValidator()
        {
            RuleFor(x => x.Dto.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Dto.Price).NotEmpty();
            RuleFor(x => x.Dto.Description).NotEmpty();
            RuleFor(x => x.Dto.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(x => x.Dto.Measurement).Must(x => Measurement.Measurements.Contains(x));
        }
    }
}
