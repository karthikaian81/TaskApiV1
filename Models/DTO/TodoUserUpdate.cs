using System.ComponentModel.DataAnnotations;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserUpdate
    {
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        [StringLength(160)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(30)]
        public string RoleName { get; set; }

        [Required]
        [FutureDateValidations(DateCustomErrorMessage = "Date Should not be Future date")]
        [DateRangeValidations("01-01-1970", "31-12-2004")]
        public DateTime DOB { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}
