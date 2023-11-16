using Microsoft.VisualStudio.TestPlatform.TestHost;
using RefactorPizza;

namespace PizzaTests
{
    [TestClass]
    public class PizzaTest
    {
        [TestMethod]
        public void TestPizza1()
        {
            RefactorPizza.Program.Load();

            Order o1 = new(new Pizza("ham", "large"), true);
            const string expectedPrice = "9,20";

            Assert.AreEqual(o1.GetFullPrice().ToString("F2"), expectedPrice);
        }

        [TestMethod]
        public void TestPizza2()
        {
            RefactorPizza.Program.Load();

            Order o2 = new(new Pizza("mushroom", "medium"));
            const string expectedPrice = "6,00";

            Assert.AreEqual(o2.GetFullPrice().ToString("F2"), expectedPrice);
        }

        [TestMethod]
        public void TestPizza3()
        {
            RefactorPizza.Program.Load();

            Order o3 = new(new Pizza("everything", "small"), true);
            const string expectedPrice = "10,00";

            Assert.AreEqual(o3.GetFullPrice().ToString("F2"), expectedPrice);
        }

        [TestMethod]
        public void TestPizza4()
        {
            RefactorPizza.Program.Load();

            Order o4 = new(new Pizza("pineapple", "large"), true);
            const string expectedPrice = "10,40";

            Assert.AreEqual(o4.GetFullPrice().ToString("F2"), expectedPrice);
        }
    }
}