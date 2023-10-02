using System.ComponentModel.DataAnnotations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string?  EmailId { get; set; } 

        [Required]
        [DataType (DataType.Password)]
        public string? Password { get; set; }
    }
}
