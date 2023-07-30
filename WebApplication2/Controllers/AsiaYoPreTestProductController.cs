using Microsoft.AspNetCore.Mvc;
using Project.Model;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiaYoPreTestProductController : ControllerBase
    {
        /// <summary>
        /// 匯率轉換 API
        /// </summary>
        /// <param name="source">要轉換的原始貨幣代碼 (例如 "TWD")</param>
        /// <param name="target">目標貨幣代碼 (例如 "USD")</param>
        /// <param name="amount">要轉換的金額 (例如 "1000")</param>
        /// <returns></returns>
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