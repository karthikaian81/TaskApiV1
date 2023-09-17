using System.ComponentModel.DataAnnotations;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserSignupCreate
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordCustomValidation(Minlen:8,MinlenRest:true,MaxlengthRest = true,PwdMaxlength = 26)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Password and confirm password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
