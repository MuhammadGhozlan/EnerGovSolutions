using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S_Squared_Enterprises_Personal_System.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
               
        [ForeignKey(nameof(EmployeeID))]        
        public int? ManagerID { get; set; }
        public Employee Manager { get; set; }


    }
}
