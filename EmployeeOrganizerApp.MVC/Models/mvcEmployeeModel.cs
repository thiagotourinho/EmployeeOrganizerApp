using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeOrganizerApp.MVC.Models
{
    public class mvcEmployeeModel
    {
       
        public int EmployeeID { get; set; }
        public string Name { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = "";
        public string Email { get; set; } = "";
        public string CPF { get; set; } = "";
      
        public DateTime StartDate { get; set; }

        public string? Team { get; set; }
    }
}
