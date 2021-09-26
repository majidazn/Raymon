using Raymon.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Register
{
    public interface IRegisterService
    {
        Task<bool> CreateUser(CreateUserDto createUserDto);
    }
}
