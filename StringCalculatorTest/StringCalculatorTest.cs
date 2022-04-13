using NUnit.Framework;
using System;
using StringCalculatorTDD;

namespace StringCalculatorTest
{
    public class StringCalculatorTest
    {
        [Test]
        public void TestForEmptyString()
        {
            Assert.AreEqual(0, StringCalculator.IsEmptyString(""));
        }
        [Test]
        public void TestForExtractNumbers()
        {
            Assert.AreEqual(23, StringCalculator.Add("3,5,7,8,0"));
        }
        [Test]
        public void TestHandleNewLineDelimiter()
        {
            Assert.AreEqual(6, StringCalculator.Add("1\n2,3"));
        }
        [Test]
        public void TestForHandlingNewDelimiter()
        {
            Assert.AreEqual(25, StringCalculator.Add("//;\n3;5;7;8;2"));
        }
        [Test]
        public void TestForNegativeNumbers()
        {
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("3,-2,5,6"));
            Assert.AreEqual("Negatives not allowed.", ex.Message);
        }
        [Test]
        public void TestAlreadyExisitingDelimiter()
        {
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("//,\n3;5;7;8;2"));
            Assert.AreEqual("Delimiter already Exists", ex.Message);
        }
    }
}
