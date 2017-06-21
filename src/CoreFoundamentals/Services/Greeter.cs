using Microsoft.Extensions.Configuration;

namespace CoreFoundamentals.Services
{
    public interface IGreeter
    {
        string GetGreetintg();
    }

    public class Greeter:IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration)
        {
            _greeting=configuration["greeting"];
        }
        public string GetGreetintg()
        {
            //_greeting= "Hello from greeter!";
            return _greeting;

        }
    }
}