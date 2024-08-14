using Bogus;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Taschenrechner.WinForms;

namespace Taschenrechner.Business.Test {

    [TestClass]
    public class CalculatorTest {

        [TestMethod]
        public void clearTest() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.Clear();

            Assert.AreEqual(string.Empty, sut.GetCurrentCalculation());
        }

        [TestMethod]
        public void decimalTest() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter("4");
            sut.AddDecimalPoint();
            sut.AddCharacter("2");
            sut.AddCharacter("5");
            sut.AddCharacter("^");
            sut.AddCharacter("3");

            var result = sut.Evaluate();

            Assert.AreEqual("76.765625", result);

        }

        [TestMethod]
        public void evaluationTypeTest() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter("(");
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(")");

            var result = sut.Evaluate();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void firstOperatorTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsFalse(sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^")));
        }

        [TestMethod]
        public void historyTest() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter("(");
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.PickRandom<string>("+", "-", "*", "/", "^"));
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(")");

            var result = sut.Evaluate();
            var history = sut.HistoryString;

            Assert.AreEqual(result, history);
        }

        [TestMethod]
        public void invalidCharTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsFalse(sut.AddCharacter(fake.Random.String(length: 1)));
        }

        [TestMethod]
        public void NumbersTest() {
            var fake = new Faker();
            var sut = new Calculator();

            Assert.IsTrue(sut.AddCharacter(fake.Random.Number(0, 9).ToString()));
        }
        [TestMethod]
        public void orderOfOperationsTest() {
            var sut = new Calculator();

            sut.AddCharacter("3");
            sut.AddCharacter("+");
            sut.AddCharacter("5");
            sut.AddCharacter("*");
            sut.AddCharacter("4");

            var result = sut.Evaluate();

            Assert.AreEqual("23", result);
        }

        [TestMethod]
        public void signToggling() {
            var fake = new Faker();
            var sut = new Calculator();

            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.AddCharacter(fake.Random.Number(1, 9).ToString());
            sut.ToggleSign();

            Assert.IsTrue(Convert.ToInt32(sut.GetCurrentCalculation()) < 0);
        }

        [TestMethod]
        public void
    }
}