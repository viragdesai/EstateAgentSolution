using EstateAgentSolution.DataModel.Context;
using EstateAgentSolution.DataModel.Repository.Abstract;
using EstateAgentSolution.DataModel.Repository.Concrete;
using EstateAgentSolution.DataModel.UnitOfWork.Abstract;
using EstateAgentSolution.Entities.Dto;
using System;

namespace EstateAgentSolution.DataModel.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext { get; set; }
        private IRepository<Employee> _employeeRepository;

        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (this._employeeRepository == null)
                    this._employeeRepository = new Repository<Employee>(_dbContext);
                return _employeeRepository;
            }
        }

        public UnitOfWork(ApplicationDbContext bloggingContext)
        {
            _dbContext = bloggingContext;
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
