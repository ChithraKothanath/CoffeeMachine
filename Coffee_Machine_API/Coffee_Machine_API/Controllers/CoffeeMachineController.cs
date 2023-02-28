using Coffee_Machine_API.Models;
using Coffee_Machine_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Coffee_Machine_API.Controllers
{

    [ApiController]
    public class CoffeeMachineController : ControllerBase
    {
     
        private readonly ICoffeeService _coffeeService;
        private readonly IWeatherService _weatherService;


        #region Constructor
        public CoffeeMachineController(ICoffeeService coffeeService, IWeatherService weatherService)
        {
            _coffeeService = coffeeService;
            _weatherService = weatherService;
        }
        #endregion


        [HttpGet]
        [Route("/brew-coffee")]
        public  async Task< IActionResult> GetBrewCoffee()
        {
            var creationCount =  _coffeeService.GetBrewCoffeeCount();
           

            if (CoffeeStaticService.IsAprilFirst())
            {
                return StatusCode(StatusCodes.Status418ImATeapot, null);
            }
            else if (_coffeeService.IsResetCoffeeMachine())
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, null);
            }
            else if (await _weatherService.GetTemperature() <= 30)
            {
                return Ok(new BrewCoffee("Your piping hot coffee is ready"));
            }
            else
            {
                return Ok(new BrewCoffee("Your refreshing iced coffee is ready"));
            }
        }

       
    }
}
