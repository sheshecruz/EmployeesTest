using DAL;
using DAL.DTO;
using DAL.Models;
using MVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View(new List<EmployeeViewModel>());
        }

        public async Task<ActionResult> Search(string searchText)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            List<EmployeeViewModel> employeeVmList = new List<EmployeeViewModel>();
            if (String.IsNullOrEmpty(searchText)) {
                employees = await EmployeeService.GetAllEmployeeDTO();
            }
            else
            {
                EmployeeDTO employeeById = await EmployeeService.GetEmployeeDTOById(Int32.Parse(searchText));
                if (employeeById != null)
                    employees.Add(employeeById);
            }
                
            if(employees != null && employees.Count > 0)
            {
                employeeVmList = employees.Select(edto => EmployeeViewModel.ConvertToViewModel(edto)).ToList();
            }
            

            return PartialView("_EmployeeTable", employeeVmList);
        }
    }
}