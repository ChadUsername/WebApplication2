using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;

namespace Project.Tests
{
    [TestClass]
    public class AsiaYoPreTestProductControllerTests
    {
        [TestMethod]
        public void TestExchangeRate_ValidInput_Success()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "USD";
            string amount = "1000";

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);
            // 根據你的測試案例添加更多斷言
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_Failure()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "XYZ"; // 這是一個無效的貨幣代碼
            string amount = "abc"; // 這是一個無效的金額

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("傳入參數amount為非數字", response.msg);
            // 根據你的測試案例添加更多斷言
        }

        // 可以繼續添加更多測試案例
    }
}