using TaskApiV1.CustomValidations;

namespace TaskApiV1.Models.DTO
{
    public class TodoTestGet
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Remarks { get; set; }

        public Int64 UserId { get; set; }

        public Int64 PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EstimatedCompletedOn { get; set; }
    }
}
