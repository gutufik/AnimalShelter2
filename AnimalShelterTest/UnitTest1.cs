using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Configuration;

namespace AnimalShelterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var strings = ConfigurationManager.ConnectionStrings;
            DataAccess.GetAnimal(1);
            //var users = DataAccess.GetUsers();
        }
    }
}
