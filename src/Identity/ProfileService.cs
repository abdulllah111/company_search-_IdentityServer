using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Models;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace Identity
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Subject, user.Id),
            new Claim(JwtClaimTypes.Email, user.Email),
            // Добавляем дополнительные утверждения
            // new Claim(JwtClaimTypes.GivenName, user.FirstName),
            // new Claim(JwtClaimTypes.FamilyName, user.LastName),
            new Claim(JwtClaimTypes.BirthDate, user.BirthDate.ToString("yyyy-MM-dd")),
            new Claim(JwtClaimTypes.Gender, user.Gender.ToString()),
            // Другие утверждения...
        };

            context.IssuedClaims.AddRange(claims);
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.FindByIdAsync(context.Subject.GetSubjectId());
            context.IsActive = user != null && user.IsActive; // Здесь IsActive может быть вашим пользовательским свойством, которое указывает на активность пользователя

        }
    }
}