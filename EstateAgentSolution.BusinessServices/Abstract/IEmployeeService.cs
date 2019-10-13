using EstateAgentSolution.Entities.Entity;
using System.Collections.Generic;

namespace EstateAgentSolution.BusinessServices.Abstract
{
    public interface IEmployeeService
    {
        EmployeeEntity GetEmployeeById(int id);
        IEnumerable<EmployeeEntity> GetAllEmployees();
    }
}
