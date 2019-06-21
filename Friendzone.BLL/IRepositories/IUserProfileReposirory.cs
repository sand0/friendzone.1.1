using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.Core.IRepositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        UserProfile GetProfileWithAllFields(int id);
        IEnumerable<UserProfile> AllProfilesWithAllFields();
    }
}
