using Microsoft.AspNetCore.Identity;
using Raymon.Common.Dtos;
using Raymon.DataAccess.Context;
using Raymon.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Register
{
    public class RegisterService : IRegisterService
    {

        RaymonContext _dbContext;
        private UserManager<User> _userManager;
        public RegisterService(UserManager<User> userManager, RaymonContext dbContext) : base()
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUser(CreateUserDto createUserDto)
        {

            User user = new User
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                UserName = createUserDto.UserName
            };



            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
