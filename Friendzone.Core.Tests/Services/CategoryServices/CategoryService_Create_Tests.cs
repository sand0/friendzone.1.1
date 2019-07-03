using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Friendzone.Core.Services;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Core.Tests.Services.CategoryServices
{
    [TestFixture]
    public class CategoryService_Create_Tests
    {
        private readonly ICategoryService _categoryService;

        public CategoryService_Create_Tests()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.CategoryRepository.Create(It.IsAny<Category>()));
            unitOfWork.Setup(x => x.CategoryRepository.Get())
                .Returns(new List<Category>()
                {
                    new Category { Id = 1, Name = "NameIsExist" }
                }
                .AsQueryable());

            _categoryService = new CategoryService(unitOfWork.Object);
        }

        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public async Task CategoryService_Create_RetunTrue()
        {
            // Arrange
            Category newCategory = new Category { Id = 0, Name = "test" };

            // Act
            var result = await _categoryService.CreateAsync(newCategory);

            // Assert
            Assert.IsTrue(result.Succedeed);
        }

        [Test]
        [TestCaseSource(typeof(CategoryWitoutNameTestDataSource))]
        public async Task CategoryService_CreateWithoutName_RetunFalse(Category category)
        {
            // Arrange

            // Act
            var result = await _categoryService.CreateAsync(category);

            // Assert
            Assert.IsFalse(result.Succedeed);
        }

        [Test]
        public async Task CategoryService_CreateWithSameName_RetunFalse()
        {
            // Arrange
            Category newCategory = new Category { Id = 0, Name = "NameIsExist" };
            
            // Act
            var result = await _categoryService.CreateAsync(newCategory);

            // Assert
            Assert.IsFalse(result.Succedeed);
        }

        [Test]
        public async Task CategoryService_CreateWithNotNullId_RetunFalse()
        {
            // Arrange
            Category newCategory = new Category { Id = 1, Name = "SomeName" };

            // Act
            var result = await _categoryService.CreateAsync(newCategory);

            // Assert
            Assert.IsFalse(result.Succedeed);
        }
    }

    public class CategoryWitoutNameTestDataSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {   
            yield return new Category { Id = 0, Name = ""};
            yield return new Category { Id = 0 };
        }
    }

}