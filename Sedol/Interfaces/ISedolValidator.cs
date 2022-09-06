namespace SedolValidator.Interfaces
{
    /// <summary>
    /// SedolValidator Interface.
    /// </summary>
    public interface ISedolValidator
    {
        /// <summary>
        /// A method to validate a sedol value.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Sedol validation result instance.</returns>
        ISedolValidationResult ValidateSedol(string input);
    }
}
