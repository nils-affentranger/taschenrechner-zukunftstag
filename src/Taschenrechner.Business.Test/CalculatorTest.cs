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

        [TestMethod]
        public void firstOperatorTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsFalse(sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^")));
        }

        [TestMethod]
        public void invalidCharTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsFalse(sut.AddCharacter("A"));
        }

        [TestMethod]
        public void AddCharacter_andEvaluate() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter(fake.Random.Number(1, 100).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter("(");
            sut.AddCharacter(fake.Random.Number(1, 100).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter(fake.Random.Number(1, 100).ToString());
            sut.AddCharacter(")");

            var result = sut.Evaluate();

            Assert.IsInstanceOfType(result, typeof(string));
        }
    }
}