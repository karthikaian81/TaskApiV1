using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoTestUpdate
    {
        [JsonIgnore]
        public int TaskId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(500)]
        public string Remarks { get; set; }

        [EstimatedDateValidation]
        public DateTime EstimatedCompletedOn { get; set; }
    }
}
