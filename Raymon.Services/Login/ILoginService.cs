using Raymon.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Login
{
    public interface ILoginService
    {
        Task<LoginReturnDto> UserLogin(LoginDto loginDto);
    }
}
