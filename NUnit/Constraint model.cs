using System;

public class Class1
{
    [TestFixture]
    [Category("Constraint model")]
    public class Constraint_model
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
            Assert.That(firstString, Is.EqualTo(secondString));
        }
        [Test]
        public void areListOfStringsEqual()
        {
            List<string> firstAndLastName = new List<string>()
            {
                "Jenna Doe",
                "Another Doe"
            };
            List<string> anotherfirstAndLastName = new List<string>()
            {
                "Jenna Doe",
                "Another Doe"
            };
            Assert.That(firstAndLastName, Is.EqualTo(anotherfirstAndLastName));
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
            Assert.That(devices, Does.Contain(laptop));
        }
        [Test]
        public void isAMoreThanB()
        {
            int a = 10;
            int b = 5;
            Assert.That(a > b, Is.True);
        }
    }
}
