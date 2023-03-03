using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Features.Commands.Product.DeleteProduct;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Commands.Product
{
    public class DeleteProductCommandTest
    {
        private readonly Mock<IProductService> productService;

        public DeleteProductCommandTest()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public async Task UpdateProductCommandHandler_Should_Return_BaseResponse_Success()
        {
            // Arrange
            var request = new DeleteProductCommandRequest()
            {
                Id = 1
            };

            productService.Setup(x => x.RemoveAsync(It.IsAny<int>())).Returns(Task.FromResult(new BaseResponse<ProductDto>(true)));

            //Act & Assert
            var handler = new DeleteProductCommandHandler(productService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
        }
    }
}
