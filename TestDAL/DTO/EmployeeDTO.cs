using DAL.DTO.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public abstract class EmployeeDTO
    {
        public static EmployeeDTO ConvertToDTO(Employee employeeEntity)
        {
            ContractType contractType = (ContractType)Enum.Parse(typeof(ContractType), employeeEntity.contractTypeName);
            EmployeeDTO employeeDTO = null;

            //Strategy pattern
            switch (contractType) {
                case ContractType.HourlySalaryEmployee:
                    employeeDTO = new EmployeeHourlyDTO();
                    break;
                case ContractType.MonthlySalaryEmployee:
                    employeeDTO = new EmployeeMonthlyDTO();
                    break;
            }

            employeeDTO.Id = employeeEntity.id;
            employeeDTO.Name = employeeEntity.name;
            employeeDTO.RoleId = employeeEntity.roleId;
            employeeDTO.RoleName = employeeEntity.roleName;
            employeeDTO.RoleDescription = employeeEntity.roleDescription;
            employeeDTO.HourlySalary = employeeEntity.hourlySalary;
            employeeDTO.MonthlySalary = employeeEntity.monthlySalary;

            return employeeDTO;
        }
        public abstract double CalculateAnnualSalary();

        #region attributes
        public int Id { get; set; }
        public string Name { get; set; }
        public ContractType ContractTypeEnum { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
        #endregion
    }
}
