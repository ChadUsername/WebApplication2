using Microsoft.AspNetCore.Mvc;
using Project.Model;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiaYoPreTestProductController : ControllerBase
    {
        [HttpGet]
        public RateResponse Get(string source, string target, string amount)
        {
            AsiaYoPreTestProductModel model = new AsiaYoPreTestProductModel();
            var reponse = model.ExchangeRate(source, target, amount);
            return reponse;
        }
    }
}