using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.DTO;
using DAL.DTO.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace DAL_Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public async Task EmployeeWithHourlySalaryTest()
        {
            List<EmployeeDTO> employeeDTOs = await EmployeeService.GetAllEmployeeDTO();
            EmployeeDTO hourlyEmployee = employeeDTOs.Where(emp => emp.ContractTypeEnum == ContractType.HourlySalaryEmployee).FirstOrDefault();
            double annualSalary = 120 * hourlyEmployee.HourlySalary * 12;

            NUnit.Framework.Assert.AreEqual(hourlyEmployee.CalculateAnnualSalary(), annualSalary, "Annual salaries are equal");
        }

        [TestMethod]
        public async Task EmployeeWithMonthlySalaryTest()
        {
            List<EmployeeDTO> employeeDTOs = await EmployeeService.GetAllEmployeeDTO();
            EmployeeDTO monthlyEmployee = employeeDTOs.Where(emp => emp.ContractTypeEnum == ContractType.MonthlySalaryEmployee).FirstOrDefault();
            double annualSalary = monthlyEmployee.MonthlySalary * 12;

            NUnit.Framework.Assert.AreEqual(monthlyEmployee.CalculateAnnualSalary(), annualSalary, "Annual salaries are equal");
        }

        [TestMethod]
        public async Task EmployeeFound()
        {
            EmployeeMonthlyDTO employeeDTOTestData = new EmployeeMonthlyDTO();
            employeeDTOTestData.Id = 2;
            employeeDTOTestData.Name = "Sebastian";
            employeeDTOTestData.ContractTypeEnum = ContractType.MonthlySalaryEmployee;
            employeeDTOTestData.RoleId = 2;
            employeeDTOTestData.RoleName = "Contractor";
            employeeDTOTestData.RoleDescription = null;
            employeeDTOTestData.HourlySalary = 60000;
            employeeDTOTestData.MonthlySalary = 80000;

            EmployeeDTO employeeDTOFound = await EmployeeService.GetEmployeeDTOById(2);


            NUnit.Framework.Assert.That(employeeDTOTestData.Id, Is.EqualTo(employeeDTOFound.Id));
            NUnit.Framework.Assert.That(employeeDTOTestData.Name, Is.EqualTo(employeeDTOFound.Name));
            NUnit.Framework.Assert.That(employeeDTOTestData.ContractTypeEnum, Is.EqualTo(employeeDTOFound.ContractTypeEnum));
            NUnit.Framework.Assert.That(employeeDTOTestData.RoleId, Is.EqualTo(employeeDTOFound.RoleId));
            NUnit.Framework.Assert.That(employeeDTOTestData.RoleName, Is.EqualTo(employeeDTOFound.RoleName));
            NUnit.Framework.Assert.That(employeeDTOTestData.RoleDescription, Is.EqualTo(employeeDTOFound.RoleDescription));
            NUnit.Framework.Assert.That(employeeDTOTestData.HourlySalary, Is.EqualTo(employeeDTOFound.HourlySalary));
            NUnit.Framework.Assert.That(employeeDTOTestData.MonthlySalary, Is.EqualTo(employeeDTOFound.MonthlySalary));
            NUnit.Framework.Assert.That(employeeDTOTestData.CalculateAnnualSalary(), Is.EqualTo(employeeDTOFound.CalculateAnnualSalary()));

            NUnit.Framework.Assert.AreEqual(employeeDTOFound, employeeDTOTestData, "Annual salaries are equal");

        }
    }
}
