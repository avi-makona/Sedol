using NUnit.Framework;

namespace SedolValidator.Tests
{
    [TestFixture]
    public class SedolTests
    {
        #region "Positive test cases."
        [Test]
        public void CheckCharacterCodeForA()
        {
            var actual = Sedol.CharacterCode('A');
            Assert.AreEqual(10, actual);
        }

        [Test]
        public void CheckCharacterCodeFor1()
        {
            var actual = Sedol.CharacterCode('1');
            Assert.AreEqual(1, actual);
        }

        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void ValidUserDefinedSedol(string input)
        {
            Sedol sedol = new Sedol(input);
            Assert.IsTrue(sedol.IsUserDefined);
        }
        #endregion

        #region "Negative test cases."
        [TestCase("9123_51")]
        [TestCase("VA.CDE8")]
        public void InValidCharacters(string input)
        {
            Sedol sedol = new Sedol(input);
            Assert.IsFalse(sedol.IsAlphaNumeric);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("123456789")]
        [TestCase("12")]
        public void InValidLengthCheck(string input)
        {
            Sedol sedol = new Sedol(input);
            Assert.IsFalse(sedol.IsValidLength);
        }

        [TestCase("9123451")]
        [TestCase("9ABCDE8")]
        public void UserDefinedSedolsWithIncorrectChecksum(string input)
        {
            Sedol sedol = new Sedol(input);
            Assert.IsFalse(sedol.HasValidTrailingCheckDigit);
        }
        #endregion
    }
}
