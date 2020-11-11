using DAL.DTO.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class EmployeeHourlyDTO : EmployeeDTO
    {
        public EmployeeHourlyDTO ()
        {
            ContractTypeEnum = ContractType.HourlySalaryEmployee;
        }

        public override double CalculateAnnualSalary()
        {
            return 120 * HourlySalary * 12;
        }

       
    }
}
