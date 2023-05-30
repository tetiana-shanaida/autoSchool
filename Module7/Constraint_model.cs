using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7
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
        public void AreStringsEqual()
        {
            string firstString = "This is test string";
            string secondString = "This is test string";
            Assert.That(firstString, Is.EqualTo(secondString));
        }

        [Test]
        public void AreListOfStringsEqual()
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
        public void DoListContainsString()
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
        public void IsAMoreThanB()
        {
            int a = 10;
            int b = 5;
            Assert.That(a > b, Is.True);
        }
    }
}
