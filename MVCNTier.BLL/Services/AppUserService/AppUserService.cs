using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MVCNTier.BLL.Models.DTOs;
using MVCNTier.Core.Entities;
using MVCNTier.Core.Entities.Enums;
using MVCNTier.Core.IRepositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        //Identity yardımcı yapıları

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IMapper mapper;

        private readonly IAppUserRepository appUserRepository;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
        }

        public async Task<UpdateProfileDTO> GetById(string id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(selector: x=> new UpdateProfileDTO
            {
                Id = id,
                FullName = x.FullName,
                UserName = x.UserName,
                Email = x.Email,
                ImagePath = x.ImagePath
            },
            expression: x => x.Id == id && x.Status != Status.Passive
            );
            return user;
        }

        public async Task<SignInResult> LogIn(LoginDTO model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            //Yeni bir AppUser nesnesi oluştur
            var user = new AppUser();
            user = mapper.Map(model, user); //DTO'dan AppUser'a verileri map'le
            var result = await userManager.CreateAsync(user,model.Password);

            #region Member isimli bir role varsa kullan yoksa oluştur, sonra kullan
            var defaultRole = roleManager.FindByIdAsync("Member").Result;
            if(defaultRole == null)
            {
                var role = new IdentityRole();
                role.Name = "Member";
                await roleManager.CreateAsync(role);
                defaultRole = roleManager.FindByNameAsync("Member").Result;

            }
            #endregion

            //Oluşturduğumuz user'a role ata
            IdentityResult roleResult = await userManager.AddToRoleAsync(user, defaultRole.Name);
            

            //Claim
            var userClaims = await userManager.GetClaimsAsync(user);
            Claim claim = new Claim("age","18");
            if (!userClaims.Any(x => x.Type == "age")) await userManager.AddClaimAsync(user, claim);

            //Oluşturulmuş user'ı sign in yap
            if (result.Succeeded) await signInManager.SignInAsync(user, false);
            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            var user = await appUserRepository.GetWhere(x => x.Id == model.Id);
            if(user != null)
            {
                if(model.UploadPath != null)
                {
                    using var image = Image.Load(model.UploadPath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    var guid = Guid.NewGuid();
                    await image.SaveAsJpegAsync($"wwwroot/images/users/{guid}.jpg");
                    user.ImagePath = $"/images/users/{guid}.jpg";
                }
                if (model.FullName != null)
                {
                    user.FullName = model.FullName;
                    appUserRepository.Update(user);
                }

                if(model.Password != null)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
                    await userManager.UpdateAsync(user);
                }

                if(model.Email != null)
                {
                    await userManager.SetEmailAsync(user, model.Email);
                }

                if (model.UserName != null)
                {
                    await userManager.SetUserNameAsync(user, model.UserName);
                }


                //önce signout yapılabilir
                await signInManager.SignInAsync(user,false);

                

            }
        }
    }
}
