using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApiV1.Models.Properties
{
    public class TodoUserSignupFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string VeificationToken { get; set; }

        public DateTime? Verifiedon { get; set; }

        public string? ResetToken  { get; set; }

        public DateTime? ResetTokenExpireson { get; set; }

        public int PasswordResettedCount { get; set; }

        public int Active { get; set; } = 0;

        public DateTime Createdon { get; set;}  = DateTime.Now;

        public DateTime? Updatedon { get; set;}

    }
}
