using Coffee_Machine_API.Models;

namespace Coffee_Machine_API.Services
{
    public interface ICoffeeService
    {
        public  int GetBrewCoffeeCount();
        public bool IsAprilFirst();
        public bool IsResetCoffeeMachine();
    }
   
}
