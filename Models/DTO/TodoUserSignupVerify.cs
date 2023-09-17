using System.ComponentModel.DataAnnotations;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserSignupVerify
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [PasswordCustomValidation(Minlen: 8, MinlenRest: true, MaxlengthRest = true, PwdMaxlength = 26)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string VerificationToken { get; set; }
    }
}
