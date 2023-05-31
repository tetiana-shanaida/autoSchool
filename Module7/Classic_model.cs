
namespace Module7
{
    [TestFixture]
    [Category("Classic model")]
    public class Classic_model
    {
        private string firstString;
        private string secondString;
        private List<string> firstAndLastName;
        private List<string> anotherfirstAndLastName;
        private List<string> devices;
        private string laptop;
        private int a;
        private int b;

        [SetUp]
        public void Setup()
        {
            firstString = "This is test string";
            secondString = "This is test string";
            firstAndLastName = new List<string>();
            anotherfirstAndLastName = new List<string>();
            devices = new List<string>();
            laptop = "laptop";
            a = 10;
            b = 5;
        }

        [TearDown]
        public void TearDown()
        {
            firstString = null;
            secondString = null;
            firstAndLastName.Clear();
            anotherfirstAndLastName.Clear();
            devices.Clear();
        }

        [Test]
        public void AreStringsEqual()
        {
            StringAssert.AreEqualIgnoringCase(firstString, secondString);
        }

        [Test]
        public void AreListOfStringsEqual()
        {
            firstAndLastName.Add("Jenna Doe");
            firstAndLastName.Add("Another Doe");
            anotherfirstAndLastName.Add("Jenna Doe");
            anotherfirstAndLastName.Add("Another Doe");
            CollectionAssert.AreEqual(firstAndLastName, anotherfirstAndLastName);
        }

        [Test]
        public void DoListContainsString()
        {
            devices.Add("desctop");
            devices.Add("mobile");
            devices.Add("laptop");
            Assert.Contains(laptop, devices);
        }

        [Test]
        public void IsAMoreThanB()
        {
            Assert.IsTrue(a > b);
        }
    }  
}