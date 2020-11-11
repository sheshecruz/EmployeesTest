using DAL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class EmployeeMonthlyDTO : EmployeeDTO
    {   
        public EmployeeMonthlyDTO()
        {
            ContractTypeEnum = ContractType.MonthlySalaryEmployee;
        }

        public override double CalculateAnnualSalary()
        {
            return MonthlySalary * 12;
        }
    }
}
