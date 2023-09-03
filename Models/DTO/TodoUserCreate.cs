using System.ComponentModel.DataAnnotations;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserCreate
    {
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string? LastName { get; set; }


        [StringLength(160)]
        public string LoginName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [PasswordCustomValidation(8,true)]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage = "Password and confirm password should match")]   
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength (30)]
        public string RoleName { get; set; }

        [Required]
        [FutureDateValidations(DateCustomErrorMessage = "Date Should not be Future date")]
        [DateRangeValidations("01-01-1970","31-12-2004")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

    }
}
