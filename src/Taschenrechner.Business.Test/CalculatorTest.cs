using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taschenrechner.WinForms;

namespace Taschenrechner.Business.Test {
    [TestClass]
    public class CalculatorTest {
        [TestMethod]
        public void AddCharacterNumbers() {

            var sut = new Calculator();

            var faker = new Faker();
            Assert.IsTrue(sut.AddCharacter(faker.Random.Number(0,9).ToString()));
        }

        [TestMethod]
        public void AddCharacterInvalidChars() {

            var sut = new Calculator();
            var faker = new Faker();

            Assert.IsFalse(sut.AddCharacter(faker.Random.String(length: 1)));
        }
    }
}
