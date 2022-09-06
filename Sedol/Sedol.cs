using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SedolValidator
{
    /// <summary>
    /// Sedol model.
    /// </summary>
    public class Sedol
    {
        private readonly string Input;
        private readonly List<int> WeightingFactor = new List<int> { 1, 3, 1, 7, 3, 9 };
        private const int SEDOL_LENGTH = 7;
        private const char USER_DEFINED_SEDOL_CHAR = '9';

        /// <summary>
        /// Sedol constructor.
        /// </summary>
        /// <param name="input"></param>
        public Sedol(string input)
        {
            Input = input;
        }

        /// <summary>
        /// A property that checks whether a input to a class is AlphaNumeric or not.
        /// </summary>
        /// <returns></returns>
        public bool IsAlphaNumeric
        {
            get { return Regex.IsMatch(Input, "^[a-zA-Z0-9]*$"); }
        }

        /// <summary>
        /// A property that checks whether a input to a class has a valid predefined length or not.
        /// </summary>
        /// <returns></returns>
        public bool IsValidLength
        {
            get { return !String.IsNullOrEmpty(Input) && Input.Length == SEDOL_LENGTH; }
        }

        /// <summary>
        /// A property that checks whether a input to a class is a user defined sedol or not.
        /// </summary>
        /// <returns></returns>
        public bool IsUserDefined
        {
            get { return Input[0] == USER_DEFINED_SEDOL_CHAR; }
        }

        /// <summary>
        /// A property that checks whether a input to a class has a valid trailing check digit or not.
        /// </summary>
        /// <returns></returns>
        public bool HasValidTrailingCheckDigit
        {
            get { return Input [6] == CheckDigit;}
        }

        /// <summary>
        /// A method to check checkdigit based on a formula ((10 − (weighted sum modulo 10)) modulo 10).
        /// </summary>
        /// <returns>CheckDigit for a given input.</returns>
        public char CheckDigit
        {
            get
            {
                var inputElements = Input.Take(SEDOL_LENGTH - 1).Select(CharacterCode).ToList();
                var total = WeightingFactor.Zip(inputElements, (w, c) => w * c).Sum();
                return Convert.ToChar(((10 - (total % 10)) % 10).ToString());
            }
        }

        /// <summary>
        /// A property that returns the position of a number/letters. Letters have the value of 9 plus their alphabet position, such that B = 11 and Z = 35.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Character code position.</returns>
        public static int CharacterCode(char input)
        {
            if (Char.IsLetter(input))
            {
                return Char.ToUpper(input) - 55;
            }

            return input - 48;
        }
    }
}
