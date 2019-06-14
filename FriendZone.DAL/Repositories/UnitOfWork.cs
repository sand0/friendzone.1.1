using FriendZone.DAL.Data;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendZone.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Db;

        private IUserProfileRepository _profileRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private ICategoryRepository _categoryRepository;
        private IPhotoRepository _photoRepository;

        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        
        public UnitOfWork(
            AppDbContext db, 
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            Db = db;

            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }


        public IUserProfileRepository ProfileRepository =>
            _profileRepository ?? (_profileRepository = new UserProfileRepository(Db));

        public ICountryRepository CountryRepository =>
            _countryRepository ?? (_countryRepository = new CountryRepository(Db));

        public ICityRepository CityRepository =>
            _cityRepository ?? (_cityRepository = new CityRepository(Db));

        public ICategoryRepository CategoryRepository =>
           _categoryRepository ?? (_categoryRepository = new CategoryRepository(Db));

        public IPhotoRepository repository =>
            _photoRepository ?? (_photoRepository = new PhotoRepository(Db));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
    
}
