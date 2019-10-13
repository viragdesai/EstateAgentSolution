using System.ComponentModel.DataAnnotations;

namespace EstateAgentSolution.Entities.Dto
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
    }
}
