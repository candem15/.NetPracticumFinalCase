using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Moq;
using Newtonsoft.Json;
using PracticumFinalCase.Application.Dtos.Token;
using PracticumFinalCase.Application.Features.Commands.User.LoginUser;
using PracticumFinalCase.Application.Response;
using PracticumFinalCase.WebApi.Controllers;
using Shouldly;
using System.Net.Http.Json;
using System.Text;

namespace PracticumFinalCase.IntegrationTest.Endpoints
{
    public class AuthControllerTest
    {
        private HttpClient _httpClient;
        public AuthControllerTest()
        {
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot("src/Presentation/PracticumFinalCase.WebApi")).CreateClient();
        }

        [Fact]
        public async Task LoginAsync_When_ValidInputsAreGiven_Returns_StatusCodeOk_With_Response_BaseResponseTokenDto()
        {
            var content = new LoginUserCommandRequest();
            content.Dto = new Application.Dtos.User.UserLoginDto()
            {
                Password = "123smith.",
                Username = "johnsmith",
            };
            var json = JsonConvert.SerializeObject(content);
            var sendd = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Auth/Login", sendd);
            var result = await response.Content.ReadAsStringAsync();
            
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            response.Content.ShouldNotBeNull();
            result.ShouldContain("Response");
            result.ShouldContain("AccessToken");
            result.ShouldContain("UserName");
            result.ShouldContain("Role");
        }

        [Fact]
        public async Task LoginAsync_When_InvalidInputsAreGiven_Returns_StatusCodeBadRequest_With_ValidationErrors()
        {
            var content = new LoginUserCommandRequest();
            content.Dto = new Application.Dtos.User.UserLoginDto()
            {
                Password = "",
                Username = "",
            };
            var json = JsonConvert.SerializeObject(content);
            var sendd = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Auth/Login", sendd);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.BadRequest);
            response.Content.ShouldNotBeNull();
            result.ShouldContain("false");
            result.ShouldNotContain("AccessToken");
        }

        [Fact]
        public async Task LoginAsync_When_WrongUserInformationAreGiven_Returns_StatusCodeOk_With_InvalidUserInformation_Message()
        {
            var content = new LoginUserCommandRequest();
            content.Dto = new Application.Dtos.User.UserLoginDto()
            {
                Password = "test",
                Username = "testPass",
            };
            var json = JsonConvert.SerializeObject(content);
            var sendd = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Auth/Login", sendd);
            var result = await response.Content.ReadAsStringAsync();

            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
            response.Content.ShouldNotBeNull();
            result.ShouldContain("false");
            result.ShouldNotContain("AccessToken");
            result.ShouldContain("InvalidUserInformation");
        }
    }
}