using Microsoft.AspNetCore.Identity;
using MVCNTier.BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> LogIn(LoginDTO model);
        Task LogOut();
        Task<UpdateProfileDTO> GetById(string id);
        Task UpdateUser(UpdateProfileDTO model);

    }
}
