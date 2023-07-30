using Microsoft.AspNetCore.Mvc;
using Project.Model;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiaYoPreTestProductController : ControllerBase
    {
        /// <summary>
        /// �ײv�ഫ API
        /// </summary>
        /// <param name="source">�n�ഫ����l�f���N�X (�Ҧp "TWD")</param>
        /// <param name="target">�ؼгf���N�X (�Ҧp "USD")</param>
        /// <param name="amount">�n�ഫ�����B (�Ҧp "1000")</param>
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
                reponse.msg = "�ǤJ�ѼƽФŪŭ�";
            }

            return reponse;
        }
    }
}