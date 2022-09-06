namespace SedolValidator.Interfaces
{
    /// <summary>
    /// SedolValidationResult Interface.
    /// </summary>
    public interface ISedolValidationResult
    {
        /// <summary>
        /// Gets the input string that needs to be validated.
        /// </summary>
        string InputString { get; }
        /// <summary>
        /// Gets a boolean value indicating whether the input string is valid or not.
        /// </summary>
        bool IsValidSedol { get; }
        /// <summary>
        /// Gets a boolean value indicating whether the input string is user defined or not.
        /// </summary>
        bool IsUserDefined { get; }
        /// <summary>
        /// Gets the validation message in case of validation failure.
        /// </summary>
        string ValidationDetails { get; }
    }
}
