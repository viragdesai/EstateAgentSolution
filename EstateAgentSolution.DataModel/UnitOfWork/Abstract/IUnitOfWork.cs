using EstateAgentSolution.DataModel.Repository.Abstract;
using EstateAgentSolution.Entities.Dto;
using System;

namespace EstateAgentSolution.DataModel.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> EmployeeRepository { get; }
        void Save();
    }
}
