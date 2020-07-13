using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Extensions;
using System.Security.Claims;
using Domain.Options;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<UserDto> AddAsync(UserDto userDto);
        Task<int> CountAsync(Expression<Func<UserDto, bool>> predicate);
        Task<int> CountAsync();
        Task<UserDto> RemoveAsync(string key);
        Task<UserDto> UpdateAsync(UserDto userDto);
        IQueryable<UserDto> Find(Expression<Func<UserDto, bool>> predicate, int start, int length);
        IQueryable<UserDto> Get(int start, int length);
        Task<UserDto> GetAsync(string key);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ICommonService commonService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public UserService(UserManager<User> userManager
            , RoleManager<Role> roleManager
            , ICommonService commonService
            , IHttpContextAccessor httpContextAccessor
            , IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.commonService = commonService;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var accessorId = httpContextAccessor.HttpContext.GetUserId();

            var accessor = await userManager.FindByIdAsync(accessorId);

            var user = mapper.Map<User>(userDto);

            user.Deleted = false;
            user.CreatorId = accessorId;

            var result = await userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            List<Claim> userClaims = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            await userManager.AddClaimsAsync(user, userClaims);

            if (userDto.RoleIds.Count > 0)
            {

                foreach (var roleId in userDto.RoleIds)
                {
                    var role = await roleManager.FindByIdAsync(roleId);
                    if (role.Name != AllowedRoles.Admin && role.Name != AllowedRoles.Super)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }
            else
            {

                if (await userManager.IsInRoleAsync(accessor, AllowedRoles.Super))
                {
                    await userManager.AddToRoleAsync(user, AllowedRoles.Admin);
                }
                else if (await userManager.IsInRoleAsync(accessor, AllowedRoles.Admin) ||
                    await userManager.IsInRoleAsync(accessor, AllowedRoles.Subadmin))
                {
                    await userManager.AddToRoleAsync(user, AllowedRoles.User);
                }
            }

            var createdUser = await userManager.FindByEmailAsync(user.Email);

            return mapper.Map<UserDto>(createdUser);
        }

        public Task<int> CountAsync(Expression<Func<UserDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> UpdateAsync(UserDto userDto)
        {
            var user = await userManager.FindByIdAsync(userDto.Id);

            if (user == null)
            {
                return new UserDto
                {
                    Errors = new string[] { $"User not found with id == {userDto.Id}" }
                };
            }

            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));
            Claim userClaim = new Claim(ClaimTypes.NameIdentifier, user.UserName);
            await userManager.AddClaimAsync(user, userClaim);

            return mapper.Map<UserDto>(user);
        }

        public IQueryable<UserDto> Find(Expression<Func<UserDto, bool>> predicate, int start, int length)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserDto> Get(int start, int length)
        {
            var accessorId = httpContextAccessor.HttpContext.GetUserId();
            var result = (commonService.IsSuper(accessorId).Result) ?
                userManager.Users.Skip(start).Take(length) :
                userManager.Users.Where(x => x.CreatorId == accessorId)
                .Skip(start).Take(length);

            return mapper.Map<List<UserDto>>(result).AsQueryable();
        }

        public async Task<UserDto> GetAsync(string key)
        {
            var user = await userManager.FindByIdAsync(key);
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RemoveAsync(string key)
        {
            var accessorId = httpContextAccessor.HttpContext.GetUserId();

            if (accessorId == key)
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to delete yourself with id {key}" }
                };
            }


            var user = await userManager.FindByIdAsync(key);

            if (user == null)
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to find user with id {key}" }
                };
            }

            if (await userManager.IsInRoleAsync(user, AllowedRoles.Super))
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to delete Super user with id {key}" }
                };
            }

            var accessor = await userManager.FindByIdAsync(accessorId);

            var accessorRoles = await userManager.GetRolesAsync(accessor);

            var accessorRanks = roleManager.Roles.Where(x => accessorRoles.Contains(x.Name))
                .Select(x => x.Rank).ToList();

            var userRoles = await userManager.GetRolesAsync(user);

            var userRanks = roleManager.Roles.Where(x => userRoles.Contains(x.Name))
                .Select(x => x.Rank).ToList();

            var checkRole = false;

            foreach (var accessorRank in accessorRanks)
            {
                foreach (var userRank in userRanks)
                {
                    checkRole = !(accessorRank < userRank);
                    if (checkRole == false)
                    {
                        break;
                    }
                }
            }

            if (checkRole)
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to delete user with id {key} due to higher rank policy" }
                };
            }

            var result = await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            result = await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            user.Deleted = true;

            result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            return mapper.Map<UserDto>(user);
        }
    }
}
