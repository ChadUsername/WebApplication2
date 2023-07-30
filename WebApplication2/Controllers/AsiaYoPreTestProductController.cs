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
            RateResponse reponse = new RateResponse();

            if (!string.IsNullOrEmpty(source) &&
                !string.IsNullOrEmpty(source) &&
                !string.IsNullOrEmpty(amount))
            {
                reponse = model.ExchangeRate(source, target, amount);
            }
            else
            {
                reponse.msg = "傳入參數請勿空值";
            }

            return reponse;
        }
    }
}