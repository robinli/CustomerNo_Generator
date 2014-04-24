using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Groupage_client_coder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Groupage_client_coder.Tests
{
    [TestClass()]
    public class CustomerBLLTests
    {
        [TestMethod()]
        public void ClearStringTest()
        {
            CustomerBLL bll = new CustomerBLL();
            
            string source = "A' B";
            string actual = bll.ClearString(source);

            string expected = "AB";

            Assert.AreEqual(expected, actual);
        }
    }
}
