using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.Properties
{
    public class TestTodoAppFormat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Task_Id",Order =1)]
        public int TaskId { get; set; }

        [Required]
        [StringLength(20)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [DefaultValue(null)]
        [StringLength(500)]
        public string Remarks { get; set; }

        [Required]
        public Int64 UserId { get; set; }

        [Required]
        public int ProfileId { get; set; }

        [Required]
        public Int64 PhoneNumber { get; set; }

        [EstimatedDateValidation]
        public DateTime EstimatedCompletedOn { get; set; }

        //[DataType(DataType.DateTime)]
        //[Required]
        //public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Timestamp]
        public byte[] UpdatedTime { get; set; }

    }
}
