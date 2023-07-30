using System.Text.RegularExpressions;

namespace Project.Model
{
    #region API回傳資料

    public class RateResponse
    {
        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 回傳匯率轉換後金額(含貨幣符號)
        /// </summary>
        public string amount { get; set; }
    }

    public class AsiaYoPreTestProductModel
    {
        /// <summary>
        /// 匯率轉換
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public RateResponse ExchangeRate(string source, string target, string amount)
        {
            var result = new RateResponse();

            try
            {
                string nurberString = Regex.Replace(amount, @"[^\d.]", "");
                decimal number;
                bool isNumeric = decimal.TryParse(nurberString, out number);

                if (isNumeric)
                {
                    decimal rate = GetRate(source, target);

                    if (rate != 0)
                    {
                        var convertedAmount = string.Format("{0:N}", Math.Round((number * rate), 2));
                        result.amount = GetCurrencySymbol(target) + convertedAmount;
                        result.msg = "成功";
                    }
                    else
                    {
                        result.msg = "無此匯率";
                    }
                }
                else
                {
                    result.msg = "傳入參數amount為非數字";
                }
            }
            catch
            {
                result.msg = "失敗";
                //錯誤紀錄
            }

            return result;
        }

        #region 取得匯率
        /// <summary>
        /// 取得匯率
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static decimal GetRate(string source, string target)
        {
            decimal rate = 0;

            if (source == target)
            {
                rate = 1;
            }
            else
            {
                if (source == "TWD")
                {
                    if (target == "JPY")
                    {
                        rate = (decimal)3.669;
                    }
                    else if (target == "USD")
                    {
                        rate = (decimal)0.03281;
                    }
                }
                else if (source == "JPY")
                {
                    if (target == "TWD")
                    {
                        rate = (decimal)0.26956;
                    }
                    else if (target == "USD")
                    {
                        rate = (decimal)0.00885;
                    }
                }
                else if (source == "USD")
                {
                    if (target == "TWD")
                    {
                        rate = (decimal)30.444;
                    }
                    else if (target == "JPY")
                    {
                        rate = (decimal)111.801;
                    }
                }
            }

            return rate;
        }
        #endregion

        #region 取得貨幣符號
        /// <summary>
        /// 取得貨幣符號
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        public static string GetCurrencySymbol(string curr)
        {
            string currencySymbol = string.Empty;

            switch (curr)
            {
                case "TWD":
                    currencySymbol = "$";
                    break;
                case "JPY":
                    currencySymbol = "¥";
                    break;
                case "USD":
                    currencySymbol = "$";
                    break;
                default:
                    currencySymbol = "$";
                    break;
            }

            return currencySymbol;
        }
        #endregion
    }

    #endregion
}