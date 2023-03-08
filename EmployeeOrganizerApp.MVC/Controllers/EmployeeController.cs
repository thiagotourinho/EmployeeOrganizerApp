using EmployeeOrganizerApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeOrganizerApp.MVC.Controllers
{
    public class EmployeeController : Controller
    {
     
        public IActionResult Index()
        {

            IEnumerable<mvcEmployeeModel> employeeList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Employee").Result;
            employeeList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(employeeList);
        }
               
        public ActionResult AddOrEdit(int id = 0)
        {

            return View(new mvcEmployeeModel());
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel employee)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", employee).Result;


            return RedirectToAction("Index");
        }


    }
}
