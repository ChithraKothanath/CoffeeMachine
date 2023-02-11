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


        #region Constructor
        public CoffeeMachineController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        #endregion


        [HttpGet]
        [Route("/brew-coffee")]
        public  IActionResult GetBrewCoffee()
        {
            var creationCount =  _coffeeService.GetBrewCoffeeCount();
          

                if (_coffeeService.IsAprilFirst())
                {
                    return StatusCode(StatusCodes.Status418ImATeapot,null);
                }
                else if (_coffeeService.IsResetCoffeeMachine())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable,null);
                }
                else
                {
                    return Ok(new BrewCoffee());
                }
        }

       
    }
}
