using Microsoft.AspNetCore.Mvc;

namespace CoreFoundamentals.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "004-555-5555";
        }
        public string Addresss()
        {
            return "USA";
        }
    }
}