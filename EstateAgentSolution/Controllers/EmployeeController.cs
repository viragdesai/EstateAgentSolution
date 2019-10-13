using EstateAgentSolution.BusinessServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EstateAgentSolution.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }
    }
}