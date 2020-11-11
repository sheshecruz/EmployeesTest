using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {

        }

        public static EmployeeViewModel ConvertToViewModel(EmployeeDTO employeeDTO)
        {
            EmployeeViewModel employeeVM = new EmployeeViewModel();
            employeeVM.ContractTypeName = employeeDTO.ContractTypeEnum.ToString();
            employeeVM.Id = employeeDTO.Id;
            employeeVM.Name = employeeDTO.Name;
            employeeVM.RoleId = employeeDTO.RoleId;
            employeeVM.RoleName = employeeDTO.RoleName;
            employeeVM.RoleDescription = employeeDTO.RoleDescription;
            employeeVM.HourlySalary = employeeDTO.HourlySalary;
            employeeVM.MonthlySalary = employeeDTO.MonthlySalary;
            employeeVM.AnnualSalary = employeeDTO.CalculateAnnualSalary();

            return employeeVM;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }

        public double AnnualSalary { get; set; }
    }
}