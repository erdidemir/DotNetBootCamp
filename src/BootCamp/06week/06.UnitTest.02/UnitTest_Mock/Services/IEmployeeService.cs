using System.Threading.Tasks;
using UnitTest_Mock.Model;

namespace UnitTest_Mock.Services
{
    public interface IEmployeeService
    {
        Task<string> GetEmployeebyId(int empId);
        Task<Employee> GetEmployeeDetails(int empId);
    }
}
