using Entities;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category Get(int id);

        Task<OperationDetails> CreateAsync(Category categoty);
        Task<OperationDetails> EditAsync(Category categoty);
        Task<OperationDetails> DeleteAsync(int id);

    }
}
