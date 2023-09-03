using System.ComponentModel.DataAnnotations;

namespace TaskApiV1.CustomValidations
{
    public class PasswordCustomValidation :ValidationAttribute
    {
        public bool EnableMinlengthRestriction, EnableCapLetterManRestrction, EnableSmallLetterManRestriction, EnableNumberManRestriction, EnableSpecialCharManRestriction;
        public string DateCustomErrorMessage=string.Empty,Password;
        public int PwdMinlength;

        char[] SpecialChars = { '@', '#', '$', '%', '^', '&', '*', ',', '>', '?', '.' }; // SpecialChars.Any(y=>y.Equals(x))

        public PasswordCustomValidation(int Minlen,bool MinlenRest,bool CapLetterRest=false,bool SmallLetterRest = false,bool NumberManRest = false,bool SpecialCharRest = false)
        {
            PwdMinlength = Minlen;
            EnableMinlengthRestriction = MinlenRest;
            EnableCapLetterManRestrction = CapLetterRest;
            EnableSmallLetterManRestriction = SmallLetterRest;
            EnableNumberManRestriction = NumberManRest;
            EnableSpecialCharManRestriction = SpecialCharRest;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value.GetType() == typeof(string))
            {
                Password = (string)value;
                if(EnableMinlengthRestriction&&(string.IsNullOrEmpty(Password)||Password.Length < PwdMinlength))
                {
                    return new ValidationResult(ErrorMessage = $"Password should Have minmumlength of {PwdMinlength} ");
                }
                if (EnableCapLetterManRestrction && !Password.Any(x=> char.IsUpper(x)))
                {
                    return new ValidationResult(ErrorMessage = $"Password should Contain a Minimum of one CapitalLetter {Password} ");
                }
                if (EnableSmallLetterManRestriction && !Password.Any(x => char.IsLower(x)))
                {
                    return new ValidationResult(ErrorMessage = $"Password should Contain a Minimum of one SmallLetter {Password} ");
                }
                if (EnableNumberManRestriction && !Password.Any(x => char.IsDigit(x)))
                {
                    return new ValidationResult(ErrorMessage = $"Password should Contain a Minimum of one Number {Password} ");
                }
                if (EnableSpecialCharManRestriction && !Password.Any(x => (!Char.IsWhiteSpace(x) &&  !char.IsLetterOrDigit(x))))
                {
                    return new ValidationResult(ErrorMessage = $"Password should Contain a Minimum of one specialcharacters {Password} ");
                }
            }
            return new ValidationResult(ErrorMessage = "This validation only works for string type property");
        }

    }
}
