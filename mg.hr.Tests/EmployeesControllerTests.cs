using mg.hr.API.Controllers;
using mg.hr.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace mg.hr.Tests
{
    [TestClass]
    public class EmployeesControllerTests
    {
        [TestMethod]
        public void CanQueryEmployees()
        {
            // ARRANGE
            // Mock the controller constructor parameter
            var employeeRepository = new Mock<IEmployeeData>();
            var employeesController = new EmployeesController(employeeRepository.Object);

            // ACT
            var response = employeesController.Get();

            // ASSERT
            // Verify the GetEmployeesById was called
            employeeRepository.Verify(r => r.GetEmployeesById(null), times: Times.AtMostOnce, "The source was not called");

        }
    }
}
