using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork Db { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public IEnumerable<Category> GetAllCategories() => Db.CategoryRepository.All();

        public Category Get(int id) => Db.CategoryRepository.Get(id);

        public async Task<OperationDetails> CreateAsync(Category category)
        {
            if (string.IsNullOrEmpty(category.Name) || category.Id != 0)
            {
                return new OperationDetails(false, "Incorrect data!", "");
            }

            if (Db.CategoryRepository.All().Any(c => c.Name == category.Name))
            {
                return new OperationDetails(false, "The same category is already exist in database", "");
            }

            Db.CategoryRepository.Create(category);

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> EditAsync(Category category)
        {
            if (category.Id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }

            Category oldCategory = Db.CategoryRepository.Get(category.Id);
            if (oldCategory == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            oldCategory.Name = category.Name;

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Category category = Db.CategoryRepository.Get(id);
            if (category == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            var result = Db.CategoryRepository.Delete(category);
            await Db.SaveAsync();
            return new OperationDetails(result, "", "");
        }
    }
}