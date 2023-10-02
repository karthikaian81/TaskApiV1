using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoTestcreate
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string Remarks { get; set; }

        [Required]
        [Range(1001,Int64.MaxValue)]
        public Int64 UserId { get; set; }

        [Required]
        [Range(1, Int64.MaxValue)]
        public Int64 ProfileId { get; set; }

        [EstimatedDateValidation]
        public DateTime EstimatedCompletedOn { get; set; }

        [Required]
        public Int64 PhoneNumber { get; set; }
    }
}
