using NUnit.Framework;

namespace SedolValidator.Tests
{
    [TestFixture]
    public class SedolValidatorTests
    {
        #region "Positive test cases"
        [TestCase("0709954")]
        [TestCase("B0YBKJ7")]
        public void ValidSedol(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            Assert.AreEqual(actual.ValidationDetails, null);
        }

        [TestCase("9123458")]
        [TestCase("9ABCDE1")]
        public void UserDefinedSedolsWithCorrectChecksum(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            Assert.AreEqual(actual.ValidationDetails,null);          
        }
        #endregion

        #region "Negative test cases"
        [TestCase("null")]
        [TestCase("123456789")]
        public void IncorrectSedolLength(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            Assert.AreEqual(actual.ValidationDetails, Constants.INPUT_STRING_INVALID_LENGTH);
        }
        
        [TestCase("VA.CDE8")]
        public void IncorrectSedolWithAlphaNumericCharacters(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            Assert.AreEqual(actual.ValidationDetails, Constants.INPUT_STRING_INVALID_CHARACTERS);
        }

        [TestCase("9123_51")]        
        public void IncorrectSedolWithCheckSum(string input)
        {
            var actual = new SedolValidator().ValidateSedol(input);
            Assert.AreEqual(actual.ValidationDetails, Constants.INPUT_STRING_INVALID_CHECKSUM);
        }
        #endregion        
    }
}
