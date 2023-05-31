using NUnit.Framework;
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
            anotherfirstAndLastName= new List<string>();
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
            Assert.That(firstString, Is.EqualTo(secondString));
        }

        [Test]
        public void AreListOfStringsEqual()
        {
            firstAndLastName.Add("Jenna Doe");
            firstAndLastName.Add("Another Doe");
            anotherfirstAndLastName.Add("Jenna Doe");
            anotherfirstAndLastName.Add("Another Doe");
            Assert.That(firstAndLastName, Is.EqualTo(anotherfirstAndLastName));
        }

        [Test]
        public void DoListContainsString()
        {
            devices.Add("desctop");
            devices.Add("mobile");
            devices.Add("laptop");
            Assert.That(devices, Does.Contain(laptop));
        }

        [Test]
        public void IsAMoreThanB()
        {
            Assert.That(a > b, Is.True);
        }
    }
}
