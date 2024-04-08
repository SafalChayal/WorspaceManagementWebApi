using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkspaceManagement.BusinessLayer.Services;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkSpaceApi.NunitTest.ServicesTesting
{
    internal class DepartmentServiceTest
    {
        private DepartmentService departmentService;
        private Mock<IDepartment> departmentRepositoryMock;
        private Mock<ILogger<DepartmentService>> loggerMock;

        [SetUp]
        public void SetUp()
        {
            // Creating mock instances for IDepartment and ILogger
            departmentRepositoryMock = new Mock<IDepartment>();
            loggerMock = new Mock<ILogger<DepartmentService>>();

            // Creating the DepartmentService instance with mocked dependencies
            departmentService = new DepartmentService(departmentRepositoryMock.Object);
        }

        [Test]
        public async Task GetAllDepartments_Success()
        {
            // Arrange
            var expectedDepartments = new List<Department>
            {
                new Department { DeptId = 2, DeptName = "Department B" },
                new Department { DeptId = 1, DeptName = "Department A" },
            };

            departmentRepositoryMock.Setup(repo => repo.GetAllDepartments()).ReturnsAsync(expectedDepartments);

            // Act
            var result = await departmentService.GetAllDepartments();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Department>>(result);

            var resultCount = result.Count();
            Assert.AreEqual(expectedDepartments.Count, resultCount);
        }


        [Test]
        public void AddDepartment_Success()
        {
            // Arrange
            var newDepartment = new Department { DeptName = "New Department" };
            var expectedDepartment = new Department { DeptId = 1, DeptName = "New Department" };

            departmentRepositoryMock.Setup(repo => repo.AddDepartment(newDepartment)).Returns(expectedDepartment);

            // Act
            var result = departmentService.AddDepartment(newDepartment);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDepartment.DeptName, result.DeptName);
        }

        [Test]
        public async Task GetDepartment_Success()
        {
            // Arrange
            var departmentId = 1;
            var expectedDepartment = new Department { DeptId = departmentId, DeptName = "Department A" };

            departmentRepositoryMock.Setup(repo => repo.GetDepartment(departmentId)).ReturnsAsync(expectedDepartment);

            // Act
            var result = await departmentService.GetDepartment(departmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDepartment.DeptName, result.DeptName);
        }
    }
}

