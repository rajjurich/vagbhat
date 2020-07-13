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
        private readonly ICommonService commonService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;       

        public UserService(UserManager<User> userManager
            , ICommonService commonService
            , IHttpContextAccessor httpContextAccessor
            , IMapper mapper)
        {
            this.userManager = userManager;
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
            user.AssociationId = await userManager.IsInRoleAsync(accessor, AllowedRoles.Super) ?
                userDto.AssociationId : accessor.AssociationId;

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

            await userManager.AddToRoleAsync(user, AllowedRoles.Admin);

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

            //var updatedUser = await userManager.FindByEmailAsync(user.Email);

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
                userManager.Users.Where(x => x.Association.AssociationName != "self")
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
                    Errors = new string[] { $"Unable to delete yourself with id = {key}" }
                };
            }


            var user = await userManager.FindByIdAsync(key);

            if (user == null)
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to find user with id = {key}" }
                };
            }

            var accessor = await userManager.FindByIdAsync(accessorId);

            var accessorRoles = await userManager.GetRolesAsync(accessor);

            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var accessorRole in accessorRoles)
            {
                foreach (var userRole in userRoles)
                {
                    if (accessorRole == userRole)
                    {
                        return new UserDto
                        {
                            Errors = new string[] { $"Unable to delete user with id {key} due to same access role" }
                        };
                    }
                }
            }

            if (await userManager.IsInRoleAsync(user, AllowedRoles.Super))
            {
                return new UserDto
                {
                    Errors = new string[] { $"Unable to delete Super user with id == {key}" }
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
