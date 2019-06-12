using FriendZone.DAL.Data;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
