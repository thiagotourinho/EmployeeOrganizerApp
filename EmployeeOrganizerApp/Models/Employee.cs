using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmployeeOrganizerApp.Util.Validation;

namespace EmployeeOrganizerApp.Models
{
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeID { get; set; }


        [Required] 
        [Column("name", TypeName = "nvarchar(30)")]
        [StringLength(
            30,
            MinimumLength = 3,
            ErrorMessage = "The user name must contain between 3 and 30 characters")]
        public string Name { get; set; } = "";


        [Required]
        [Column("birth_date", TypeName = "Date")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Required]
        [Column("gender", TypeName = "nvarchar(30)")]
        [StringLength(
            30,
            ErrorMessage = "The user name must contain between 3 and 30 characters")]
        public string Gender { get; set; } = "";

        
        [Required]
        [Column("email", TypeName = "nvarchar(40)")]
        [EmailAddress(ErrorMessage = "Invalid mail! Please provide a valid mail format.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "This is a required field. The CPF input must correspond the following Brazilian format standard: 000.000.000-00 ")]
        [Column("cpf", TypeName = "nvarchar(14)")]
        [CpfValidator]     
        public string CPF { get; set; } = "";


        [Required]
        [Column("start_date", TypeName = "Date")]
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        

        [TeamDomainValidation]
        [Required]
        [StringLength(
            10,
            MinimumLength = 3,
            ErrorMessage = "The user name must contain between 3 and 10 characters")]
        public string? Team { get; set; }

    }
}
