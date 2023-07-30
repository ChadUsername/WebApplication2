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
            // �ھڧA�����ծרҲK�[��h�_��
        }

        [TestMethod]
        public void TestExchangeRate_InvalidInput_Failure()
        {
            // �w�� (Arrange)
            var controller = new AsiaYoPreTestProductController();
            string source = "TWD";
            string target = "XYZ"; // �o�O�@�ӵL�Ī��f���N�X
            string amount = "abc"; // �o�O�@�ӵL�Ī����B

            // ��� (Act)
            var response = controller.Get(source, target, amount);

            // �_�� (Assert)
            Assert.IsNotNull(response);
            Assert.AreEqual("�ǤJ�Ѽ�amount���D�Ʀr", response.msg);
            // �ھڧA�����ծרҲK�[��h�_��
        }

        // �i�H�~��K�[��h���ծר�
    }
}