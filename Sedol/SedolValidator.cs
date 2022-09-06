using SedolValidator.Interfaces;

namespace SedolValidator
{
    /// <summary>
    /// Sedol validator model.
    /// </summary>
    public class SedolValidator : ISedolValidator
    {
        /// <summary>
        /// A method used to validate an input as a sedol.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>ISedolValidationResult</returns>
        public ISedolValidationResult ValidateSedol(string input)
        {
            var sedol = new Sedol(input);

            var validationResult = new SedolValidationResult
            {
                InputString = input,
                IsUserDefined = false,
                IsValidSedol = false,
                ValidationDetails = null
            };

            if (!sedol.IsValidLength)
            {
                validationResult.ValidationDetails = Constants.INPUT_STRING_INVALID_LENGTH;
                return validationResult;
            }            

            if (sedol.IsUserDefined)
            {
                validationResult.IsUserDefined = true;

                if (sedol.HasValidTrailingCheckDigit)
                {
                    validationResult.IsValidSedol = true;
                    return validationResult;
                }

                validationResult.ValidationDetails = Constants.INPUT_STRING_INVALID_CHECKSUM;
                return validationResult;
            }

            if (!sedol.IsAlphaNumeric)
            {
                validationResult.ValidationDetails = Constants.INPUT_STRING_INVALID_CHARACTERS;
                return validationResult;
            }

            if (sedol.HasValidTrailingCheckDigit)
                validationResult.IsValidSedol = true;
            else
                validationResult.ValidationDetails = Constants.INPUT_STRING_INVALID_CHECKSUM;

            return validationResult;
        }
    }
}
