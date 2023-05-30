namespace NUnit
{
    [TestFixture]
    [Category("Classic model")]
    public class Classic_model
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void areStringsEqual()
        {
            string firstString = "This is test string";
            string secondString = "This is test string";
            StringAssert.AreEqualIgnoringCase(firstString, secondString);
        }
        [Test]
        public void areListOfStringsEqual()
        {
            List<string> firstAndLastName = new List<string>()
            {
                "Jenna Doe",
                "Alla Doe"
            };
            List<string> anotherFirstAndLastName = new List<string>()
            {
                "Jenna Doe",
                "Alla Doe"
            };
            CollectionAssert.AreEqual(firstAndLastName, anotherFirstAndLastName);
        }
        [Test]
        public void doListContainsString()
        {
            List<string> devices = new List<string>()
            {
                "desctop",
                "mobile",
                "laptop"
            };
            string laptop = "laptop";
            Assert.Contains(laptop, devices);
        }
        [Test]
        public void isAMoreThanB()
        {
            int a = 10;
            int b = 5;
            Assert.IsTrue(a > b);
        }
    }
}