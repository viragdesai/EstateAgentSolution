using EstateAgentSolution.BusinessServices.Abstract;
using EstateAgentSolution.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgentSolution.Tests
{
    internal class EmployeeServiceFake : IEmployeeService
    {
        private readonly List<EmployeeEntity> _employees;

        public EmployeeServiceFake()
        {
            _employees = new List<EmployeeEntity>
            {
                new EmployeeEntity
                {
                    EmployeeId = 1,
                    EmployeeName = "Virag Desai"
                },
                new EmployeeEntity
                {
                    EmployeeId = 2,
                    EmployeeName = "Rutuja Desai"
                }
            };
        }

        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeEntity GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
