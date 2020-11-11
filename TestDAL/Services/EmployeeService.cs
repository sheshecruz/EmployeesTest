using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using DAL.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DAL.DTO;
using System.Linq;

namespace DAL
{
    public class EmployeeService
    {
        private static HttpClient _client = null;
        public static void InitializeHttpClient()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiURL"]);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public static async Task<List<Employee>> GetEmployeesAsync()
        {
            InitializeHttpClient();
            List<Employee> employees = null;
            HttpResponseMessage response = await _client.GetAsync("api/Employees");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(result);
            }
            return employees;
        }
        public static async Task<List<EmployeeDTO>> GetAllEmployeeDTO()
        {
            try
            {
                List<Employee> employees = await GetEmployeesAsync();
                return employees.Select(e => EmployeeDTO.ConvertToDTO(e)).ToList();
            }
            catch
            {
                return null;
            } 
        }
        public static async Task<EmployeeDTO> GetEmployeeDTOById(int employeeId)
        {
            try
            {
                List<Employee> employees = await GetEmployeesAsync();
                return employees.Where(e => e.id == employeeId).Select(e => EmployeeDTO.ConvertToDTO(e)).First();
            }
            catch
            {
                return null;
            }
        }
    }
}