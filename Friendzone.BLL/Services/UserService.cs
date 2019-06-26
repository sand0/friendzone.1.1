using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public IUnitOfWork Db { get; set; }

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            Db = uow;
            _mapper = mapper;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            if (await Db.UserManager.FindByEmailAsync(userDto.Email) != null)
            {
                return new OperationDetails(false, "Emali is exist in database", "Email");
            }

            User user = _mapper.Map<UserDTO, User>(userDto);

            var result = await Db.UserManager.CreateAsync(user, userDto.Password);

            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            // Add role
            await Db.UserManager.AddToRoleAsync(user, userDto.Role);

            UserProfile userProfile = new UserProfile { UserId = user.Id };
            
            userProfile = Db.ProfileRepository.Create(userProfile);
            
            user.ProfileId = userProfile.Id;

            result = await Db.UserManager.UpdateAsync(user);
            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            await Db.SaveAsync();

            return new OperationDetails(true, "Registration succeeded", "");
        }

        public async Task<bool> AuthenticateAsync(UserDTO userDto)
        {
            User user = await Db.UserManager.FindByEmailAsync(userDto.Email);
            
            var result = await Db.SignInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, lockoutOnFailure: false);
            
            return result.Succeeded;
        }

        public async Task<User> GetCurrentUserAsync(HttpContext context)
        {
            User user = await Db.UserManager.GetUserAsync(context.User);
            var prof = Db.ProfileRepository.Get(p => p.UserId == user.Id);
            return user;
        }

        public async Task SignOutAsync()
        {
            await Db.SignInManager.SignOutAsync();
        }

        public async Task AdminSeedAsync(UserDTO adminDto)
        {
            if (!Db.UserManager.Users.Any())
            {
                await CreateAsync(adminDto);
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        
    }
}
