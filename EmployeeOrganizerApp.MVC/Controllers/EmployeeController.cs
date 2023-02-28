﻿using EmployeeOrganizerApp.MVC.Models;
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
    }
}