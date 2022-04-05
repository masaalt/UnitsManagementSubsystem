using FluentAssertions;
using NUnit.Framework;
using Common;

namespace UnitTest
{
    public class UnitTestCommon
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ArrayExtensionTest()
        {
            string[] wordsnew = { "(", "2", "+", "3", ")" };
            wordsnew = wordsnew.RemoveAt(2);
            string[] wordsnewAns = { "(", "2", "3", ")" };
            wordsnew.Should().BeEquivalentTo(wordsnewAns);
        }

        [Test]
        public void CalcBtnPTest()
        {
            string btnP = "2+3";
            string res = ExpCalc.CalcBtnP(btnP);
            res.Should().BeEquivalentTo("5");
        }
    }
}