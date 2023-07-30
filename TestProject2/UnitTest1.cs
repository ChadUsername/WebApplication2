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
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "USD";
            string amount = "1000";

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);

            // �w�� (Arrange)
            amount = "1000.15855";

            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);

            // �w�� (Arrange)
            amount = "$1000.15855";

            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_ValidInput_Success_Special()
        {
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "USD";
            //�o�O�@�ӿ��~�����B�A�Ʀr������L�Ÿ�
            string amount = "10S4500";

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);

            // �w�� (Arrange)
            //�o�O�@�ӿ��~�����B
            amount = ".15454887";

            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);

            // �w�� (Arrange)
            //�o�O�@�ӿ��~���f���Ÿ�
            amount = "#15454887";

            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("���\", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_Failure_IsNullOrEmpty()
        {
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            // �o�O�@�ӵL�Ī��f���N�X
            string source = "";
            string target = "TWD";
            string amount = "1234";

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�ǤJ�ѼƽФŪŭ�", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_FailureNonNumeric()
        {
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "TWD";
            // �o�O�@�ӵL�Ī����B
            string amount = "abc";

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�ǤJ�Ѽ�amount���D�Ʀr", response.msg);

            // �w�� (Arrange)
            amount = "abc3232....5455.645.648";


            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�ǤJ�Ѽ�amount���D�Ʀr", response.msg);
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_NoExchangeRate()
        {
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            // �o�O�@�ӵL�Ī��f���N�X
            string target = "XYZ";
            string amount = "100";

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�L���ײv", response.msg);

            // �w�� (Arrange)
            source = "XYZ";

            // ��� (Act)
            response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�L���ײv", response.msg);
        }
    }
}