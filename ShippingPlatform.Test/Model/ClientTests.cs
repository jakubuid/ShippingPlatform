using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ShippingPlatform.Test
{
    [TestFixture]
    public class ClientTest
    {   
        [Test]
        public void CtorTest()
        {
            Client c = new Client();
            Assert.IsNotNull(c.login, "Login is null");
            Assert.IsNotNull(c.password, "Password is null");
            Assert.IsNotNull(c.addressEmail, "Address email is null");
            Assert.IsNotNull(c.clientAddress, "Client address is null");
        }

        [Test]
        [TestCase(1,2,3, "adding two positive values")]
        [TestCase(2,2,4, "adding two positive values")]
        public void AddPosotiveNumbersTest(double a, double b, double expested)
        {
            //Assert.AreEqual(expected, c.Add(a , b), UriHostNameType + "failed");
        }
    }
}
