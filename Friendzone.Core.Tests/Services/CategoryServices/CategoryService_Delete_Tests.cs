using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Friendzone.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.Tests.Services.CategoryServices
{
    class CategoryService_Delete_Tests
    {
        private readonly ICategoryService _categoryService;

        public CategoryService_Delete_Tests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.CategoryRepository.Delete(It.IsAny<Category>()));

            unitOfWork.Setup(x => x.CategoryRepository.Get(1))
                .Returns(new Category { Id = 1, Name = "NameIsExist" });

            _categoryService = new CategoryService(unitOfWork.Object);
        }

        [Test]
        public async Task CategoryService_DeleteWithoutId_RetunFalse()
        {
            // Arrange
            Category category = new Category { Id = 0, Name = "test" };

            // Act
            var result = await _categoryService.DeleteAsync(category.Id);

            // Assert
            Assert.IsFalse(result.Succedeed);
        }

        [Test]
        public async Task CategoryService_DeleteItemIfNotExist_RetunFalse()
        {
            // Arrange
            Category category = new Category { Id = 2, Name = "This isn't exist In Repo" };

            // Act
            var result = await _categoryService.DeleteAsync(category.Id);

            // Assert
            Assert.IsFalse(result.Succedeed);
        }

    }
}
