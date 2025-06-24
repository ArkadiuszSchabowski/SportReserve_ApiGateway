using Microsoft.AspNetCore.Mvc;
using SportReserve_ApiGateway.Models.User;

namespace SportReserve_ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGatewayController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiGatewayController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var client = _httpClientFactory.CreateClient("AccountService");

            var response = await client.GetAsync("");

            var result = await response.Content.ReadFromJsonAsync<List<GetUserDto>>();
            return Ok(result);
        }
    }
}