using MediatR;
using Moq;
using PracticumFinalCase.Application.Abstractions.Repositories;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Features.Commands.Product.CreateProduct;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.Product
{
    public class CreateProductCommandTest
    {
        private readonly Mock<IProductService> productService;

        public CreateProductCommandTest()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public async Task CreateProductCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new CreateProductCommandRequest()
            {
                Dto = new ProductDto()
                {
                    Name = "TestProduct",
                    Price = 10,
                    Quantity = 1,
                    Description = "testing purposes",
                    Measurement = "Electronic"
                }
            };

            productService.Setup(x => x.InsertAsync(It.IsAny<ProductDto>())).Returns(Task.FromResult(new BaseResponse<ProductDto>(true)));

            //Act & Assert
            var handler = new CreateProductCommandHandler(productService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            var request = new CreateProductCommandRequest()
            {
                Dto = new ProductDto()
                {
                    Name = "",
                    Price = -5,
                    Quantity = 15,
                    Description = "testing purposes",
                    Measurement = "noCategory"
                }
            };


            // Act&Assert
            CreateProductCommandRequestValidator validator = new CreateProductCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldBeReturnNoErrors()
        {
            // Arrange
            var request = new CreateProductCommandRequest()
            {
                Dto = new ProductDto()
                {
                    Name = "NoteBook",
                    Price = 1900,
                    Quantity = 1,
                    Description = "Portable pc.",
                    Measurement = "Unit"
                }
            };


            // Act&Assert
            CreateProductCommandRequestValidator validator = new CreateProductCommandRequestValidator();
            var result = validator.Validate(request);

            result.Errors.Count.ShouldBeEquivalentTo(0);
        }

    }
}

