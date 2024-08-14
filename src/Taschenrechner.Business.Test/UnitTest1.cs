using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner.WinForms;

namespace Taschenrechner.Business.Test {
    [TestClass]
    public class CalculatorTest {
        [TestMethod]
        public void NumbersTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsTrue(sut.AddCharacter(fake.Random.Number(0, 9).ToString()));
        }
    }
}