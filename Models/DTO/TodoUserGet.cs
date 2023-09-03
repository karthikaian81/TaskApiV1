using System.ComponentModel.DataAnnotations;

namespace TaskApiV1.Models.DTO
{
    public class TodoUserGet
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string RoleName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
       // public int Active { get; set; }
    }
}
