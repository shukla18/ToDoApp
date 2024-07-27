using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DataAccessLayer;
using ToDo.Core.Models;
using Moq;
using ToDo.Core.Services;

namespace ToDo.Core.Tests
{
    [TestClass]
    public class CategoryServiceTests
    {
        private Mock<IRepository<Category>> _mockRepository;
        private IService<Category> _service;

        [TestInitialize]
        public void Inititalize()
        {
            _mockRepository = new Mock<IRepository<Category>>();
            _service = new CategoryService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnListOfCategories()
        {
            // Arrange
            var mockCategories = new List<Category> { new Category { Id = 1, Title = "Test Category" } };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockCategories);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.AreEqual(mockCategories[0].Id, result[0].Id);
        }
    }
}
