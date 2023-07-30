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

            // 安排 (Arrange)
            amount = "1000.15855";

            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);

            // 安排 (Arrange)
            amount = "$1000.15855";

            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_ValidInput_Success_Special()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "USD";
            //這是一個錯誤的金額，數字中有其他符號
            string amount = "10S4500";

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);

            // 安排 (Arrange)
            //這是一個錯誤的金額
            amount = ".15454887";

            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);

            // 安排 (Arrange)
            //這是一個錯誤的貨幣符號
            amount = "#15454887";

            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("成功", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_Failure_IsNullOrEmpty()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            // 這是一個無效的貨幣代碼
            string source = "";
            string target = "TWD";
            string amount = "1234";

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("傳入參數請勿空值", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_FailureNonNumeric()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "TWD";
            // 這是一個無效的金額
            string amount = "abc";

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("傳入參數amount為非數字", response.msg);

            // 安排 (Arrange)
            amount = "abc3232....5455.645.648";


            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("傳入參數amount為非數字", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_NoExchangeRate()
        {
            // 安排 (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            // 這是一個無效的貨幣代碼
            string target = "XYZ";
            string amount = "100";

            // 行動 (Act)
            var response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("無此匯率", response.msg);

            // 安排 (Arrange)
            source = "XYZ";

            // 行動 (Act)
            response = controller.Get(source, target, amount);

            // 斷言 (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("無此匯率", response.msg);
        }
    }
}