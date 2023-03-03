using Moq;
using PracticumFinalCase.Application.Abstractions.Services;
using PracticumFinalCase.Application.Dtos.Product;
using PracticumFinalCase.Application.Features.Queries.Product.GetAllProducts;
using PracticumFinalCase.Application.Response;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.UnitTest.Features.Queries.Product
{
    public class GetAllProductsQueryTest
    {
        private readonly Mock<IProductService> productService;

        public GetAllProductsQueryTest()
        {
            productService = new Mock<IProductService>();
        }

        [Fact]
        public async Task GetProductByIdQueryHandler_Should_Return_BaseResponse_Success_With_Product()
        {
            // Arrange
            var request = new GetAllProductsQueryRequest();

            var returnDto = new List<ProductDto>()
            {
                new ProductDto()
                {
                Name = "NoteBook",
                Price = 1900,
                Quantity = 1,
                Description = "Portable pc.",
                Measurement = "Unit" },
                new ProductDto()
                {
                Name = "NoteBook",
                Price = 1900,
                Quantity = 1,
                Description = "Portable pc.",
                Measurement = "Unit" },
                new ProductDto()
                {
                Name = "NoteBook",
                Price = 1900,
                Quantity = 1,
                Description = "Portable pc.",
                Measurement = "Unit" }

            };

            productService.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(new BaseResponse<IEnumerable<ProductDto>>(returnDto)));

            //Act & Assert
            var handler = new GetAllProductsQueryHandler(productService.Object);

            var response = await handler.Handle(request, default);

            response.ShouldNotBeNull();
            response.Success.ShouldBeTrue();
            response.Response.ShouldBeEquivalentTo(returnDto);
        }
    }
}
