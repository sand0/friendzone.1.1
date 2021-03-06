﻿using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Friendzone.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext Db;
        private bool disposed = false;

        private IUserProfileRepository _profileRepository;
        private ICountryRepository _countryRepository;
        private ICityRepository _cityRepository;
        private ICategoryRepository _categoryRepository;
        private IPhotoRepository _photoRepository;
        private IEventRepository _eventRepository;

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

        public IPhotoRepository PhotoRepository =>
            _photoRepository ?? (_photoRepository = new PhotoRepository(Db));

        public IEventRepository EventRepository =>
            _eventRepository ?? (_eventRepository = new EventRepository(Db));


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
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
