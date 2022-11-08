using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using WinFormsApp1;

namespace TestProject1
{

    public class TestFormDependency : IForm
    {
        public string Message { get; set; }

        public void DisplayMessage(string message)
        {
            Message = message;
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }



        [Test]

        public void CountButtonClick()
        {
            var formDependency = new TestFormDependency();
            var form1 = new Form1();
            form1.btnCalculate_Click(null, null);
            Assert.That(() => formDependency.Message == "You have to enter a name");

        }

        //[Test]
        //public void NumBalanceError()
        //{
        //    var form1 = new Form1();
        //    var form2=new Form2();
        //    form1.btnCalculate_Click(null, null);
        //    Assert.That(() => form1.Message == "Must be between 10k and 1MM");
        //}
    }
}

