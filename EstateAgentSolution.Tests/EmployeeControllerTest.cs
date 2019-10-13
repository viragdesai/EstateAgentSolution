using EstateAgentSolution.BusinessServices.Abstract;
using EstateAgentSolution.Controllers;
using EstateAgentSolution.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EstateAgentSolution.Tests
{
    public class EmployeeControllerTest
    {
        EmployeeController _employeeController;
        IEmployeeService _employeeService;

        public EmployeeControllerTest()
        {
            _employeeService = new EmployeeServiceFake();
            _employeeController = new EmployeeController(_employeeService);
        }

        ////[Fact]
        ////public void Get_All_Employees()
        ////{
        ////    // Act
        ////    var result = _employeeController.Index();

        ////    // Assert
        ////    var viewResult = Assert.IsType<ViewResult>(result);
        ////    var model = Assert.IsAssignableFrom<IEnumerable<EmployeeEntity>>(viewResult.ViewData.Model);
        ////    Assert.Equal(2, model.Count());
        ////}
    }
}
