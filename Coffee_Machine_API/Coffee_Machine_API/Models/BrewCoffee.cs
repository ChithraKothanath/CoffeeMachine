using Coffee_Machine_API.Services;

namespace Coffee_Machine_API.Models
{
    public class BrewCoffee
    {
        public string message { get; set; }

        public DateTimeOffset prepared { get; set; }

        
        public BrewCoffee(string msg)
        {
            message = msg;
            prepared = DateTime.Now.ToUniversalTime();
        }


    }
}
