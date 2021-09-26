using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Raymon.Common.Dtos;
using Raymon.Common.Enums;
using Raymon.DataAccess.Context;
using Raymon.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Services.Login
{
    public class LoginService: ILoginService
    {

        RaymonContext _dbContext;
        private UserManager<User> _userManager;
        public LoginService(UserManager<User> userManager, RaymonContext dbContext) : base()
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }


        public async Task<LoginReturnDto> UserLogin(LoginDto loginDto)
        {


            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
                throw new UnauthorizedAccessException("خطا");


            var now = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                        new Claim(ClaimTypes.SerialNumber, "SerialNumber"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, now.ToString(), ClaimValueTypes.Integer64),
                        new Claim(ClaimTypes.UserData, user.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(),ClaimValueTypes.Integer),
                        new Claim("UserDisplayName",user.FirstName + " " + user.LastName),
                        new Claim("TenantId", "0"),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                    
            }.ToList();

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConstantAthenticationData.TokenKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var jwt = new JwtSecurityToken(
            issuer: ConstantAthenticationData.ValidIssuer,
            audience: ConstantAthenticationData.ValidAudience,
            claims: claims,
            notBefore: now,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: signingCredentials);


            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new LoginReturnDto { IsSucceeded = true, Token = encodedJwt };

        }
    }
}
