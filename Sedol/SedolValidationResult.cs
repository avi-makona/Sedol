using SedolValidator.Interfaces;

namespace SedolValidator
{
    /// <summary>
    /// Sedol validation result model.
    /// </summary>
    public class SedolValidationResult : ISedolValidationResult
    {
        public string InputString { get; set; }
        public bool IsValidSedol { get; set; }
        public bool IsUserDefined { get; set; }
        public string ValidationDetails { get; set; }

        /// <summary>
        /// Sedol validation result default constructor.
        /// </summary>
        public SedolValidationResult()
        {

        }

        /// <summary>
        /// Sedol validation result parameter constructor.
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="isValidSedol"></param>
        /// <param name="isUserDefined"></param>
        /// <param name="validationDetails"></param>
        public SedolValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            InputString = inputString;
            IsValidSedol = isValidSedol;
            IsUserDefined = isUserDefined;
            ValidationDetails = validationDetails;
        }
    }
}
