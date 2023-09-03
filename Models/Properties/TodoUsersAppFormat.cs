using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.Properties
{
    public class TodoUsersAppFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        [StringLength(160)]
        public string UserLoginName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        [FutureDateValidations(DateCustomErrorMessage = "Date Should not be Future date")]
        public DateTime DOB { get;set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        public int Active { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;

        public DateTime? LastModifiedDate { get; set; }

        public DateTime Lastlogindate { get; set; } = DateTime.Now;

    }
}
