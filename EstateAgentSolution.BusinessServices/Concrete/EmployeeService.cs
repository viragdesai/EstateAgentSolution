using EstateAgentSolution.BusinessServices.Abstract;
using EstateAgentSolution.DataModel.UnitOfWork.Abstract;
using EstateAgentSolution.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstateAgentSolution.BusinessServices.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll().ToList();
            if (employees.Any())
            {
                List<EmployeeEntity> employeeEntities = new List<EmployeeEntity>();
                foreach (var item in employees)
                {
                    var emp = new EmployeeEntity
                    {
                        EmployeeId = item.EmployeeId,
                        EmployeeName = item.EmployeeName
                    };
                    employeeEntities.Add(emp);
                }
                return employeeEntities;
            }
            return null;
        }

        public EmployeeEntity GetEmployeeById(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByID(id);
            if (employee != null)
            {
                return new EmployeeEntity
                {
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName
                };
            }
            return null;
        }
    }
}
