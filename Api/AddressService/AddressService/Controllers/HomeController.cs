using AddressService.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AddressService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService; 

        public HomeController(ILogger<HomeController> logger, IClientService clientService)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetCleanAddress")]
        public async Task<IActionResult> Index(string message)
        {
            try
            {
                var result = await _clientService.SendPostRequest(message);
                _logger.LogInformation(result);
                return Ok(result);
            }

            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest();
            }
        }
    }
}
