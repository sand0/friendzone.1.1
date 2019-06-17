using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;

namespace Friendzone.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
