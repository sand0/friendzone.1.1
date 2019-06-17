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
        public IUnitOfWork Db { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            if (await Db.UserManager.FindByEmailAsync(userDto.Email) != null)
            {
                return new OperationDetails(false, "Emali is exist in database", "Email");
            }

            User user = new User
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
                PhoneNumber = userDto.Phone
            };
            var result = await Db.UserManager.CreateAsync(user, userDto.Password);

            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            // Add role
            await Db.UserManager.AddToRoleAsync(user, userDto.Role);

            UserProfile userProfile = new UserProfile
            {
                UserId = user.Id,
                Birthday = userDto.Birthday,
            };
            
            if (userDto.City != null && userDto.Country != null)
            {
                Country country = Db.CountryRepository.All()
                                .Where(c => c.Name == userDto.Country).FirstOrDefault()
                                ??
                                Db.CountryRepository.Create(new Country
                                {
                                    Name = userDto.Country
                                });

                City city = Db.CityRepository.All()
                    .Where(c => (c.Name == userDto.City && c.CountryId == country.Id)).FirstOrDefault()
                    ??
                    Db.CityRepository.Create(new City
                    {
                        Name = userDto.City,
                        Country = country
                    });

                userProfile.City = city;
            }

            Db.ProfileRepository.Create(userProfile);

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
            return await Db.UserManager.GetUserAsync(context.User);
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
