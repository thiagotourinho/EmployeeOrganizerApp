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
            if (id == 0)
                return View(new mvcEmployeeModel());
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("api/Employee/"+ id.ToString()).Result;

                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel employee)
        {

            if (employee.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("api/Employee", employee).Result;
                TempData["SucessMessage"] = "Saved Sucessfully";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("api/Employee/" + employee.EmployeeID, employee).Result;
                TempData["SucessMessage"] = "Updated Sucessfully";
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id) {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("api/Employee/" + id.ToString()).Result;
            TempData["SucessMessage"] = "Deleted Sucessfully";

            return RedirectToAction("Index");
        }

    }
}
