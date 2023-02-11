using Coffee_Machine_API.Services;

namespace Coffee_Machine_API.Models
{
    public class CoffeeService :ICoffeeService
    {
        public static int creationCount = 0; 
        

        public int GetBrewCoffeeCount()
        {
            creationCount++;
            return creationCount;
        }

        public bool IsAprilFirst()
        {
            if (DateTime.Now.Day == 1 && DateTime.Now.Month == 4) 
            { 
                return true;
            }
            return false;
        }
        public bool IsResetCoffeeMachine()
        {
            if (creationCount%5==0)
            {
                return true;
            }
            return false;
        }

    }

   
}
