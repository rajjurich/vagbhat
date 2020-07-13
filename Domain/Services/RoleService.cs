using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRoleService
    {
        Task<RoleDto> AddAsync(RoleDto roleDto);
        Task<int> CountAsync(Expression<Func<RoleDto, bool>> predicate);
        Task<int> CountAsync();
        Task<RoleDto> RemoveAsync(string key);
        Task<RoleDto> UpdateAsync(RoleDto roleDto);
        IQueryable<RoleDto> Find(Expression<Func<RoleDto, bool>> predicate, int start, int length);
        IQueryable<RoleDto> Get(int start, int length);
        Task<RoleDto> GetAsync(string key);
    }
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly ICommonService commonService;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public RoleService(RoleManager<Role> roleManager
            , ICommonService commonService
            , UserManager<User> userManager
            , IHttpContextAccessor httpContextAccessor
            , IMapper mapper)
        {
            this.roleManager = roleManager;
            this.commonService = commonService;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task<RoleDto> AddAsync(RoleDto roleDto)
        {
            var accessorId = httpContextAccessor.HttpContext.GetUserId();

            var accessor = await userManager.FindByIdAsync(accessorId);

            var role = mapper.Map<Role>(roleDto);

            role.Deleted = false;
            role.AssociationId = await userManager.IsInRoleAsync(accessor, AllowedRoles.Super) ?
                roleDto.AssociationId : accessor.AssociationId;

            var result = await roleManager.CreateAsync(role);

            if (!(result.Succeeded))
            {
                return new RoleDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, roleDto.Name));

            var createdRole = await roleManager.FindByNameAsync(roleDto.Name);

            return mapper.Map<RoleDto>(createdRole);
        }

        public Task<int> CountAsync(Expression<Func<RoleDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RoleDto> UpdateAsync(RoleDto roleDto)
        {
            var role = await roleManager.FindByIdAsync(roleDto.Id);

            if (role == null)
            {
                return new RoleDto
                {
                    Errors = new string[] { $"Role not found with id == {roleDto.Id}" }
                };
            }

            role.Name = roleDto.Name;
            role.Rank = roleDto.Rank;

            var result = await roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                return new RoleDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            foreach (var roleClaim in await roleManager.GetClaimsAsync(role))
            {
                await roleManager.RemoveClaimAsync(role, roleClaim);
            }

            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, roleDto.Name));

            //var updatedRole = await roleManager.FindByIdAsync(role.Id);

            return mapper.Map<RoleDto>(role);
        }

        public IQueryable<RoleDto> Find(Expression<Func<RoleDto, bool>> predicate, int start, int length)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RoleDto> Get(int start, int length)
        {
            var accessorId = httpContextAccessor.HttpContext.GetUserId();
            var result = (commonService.IsSuper(accessorId).Result) ?
                roleManager.Roles.Skip(start).Take(length) :
                roleManager.Roles.Where(x => x.Association.AssociationName != "self")
                .Skip(start).Take(length);

            return mapper.Map<List<RoleDto>>(result).AsQueryable();
        }

        public async Task<RoleDto> GetAsync(string key)
        {
            var role = await roleManager.FindByIdAsync(key);
            return mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> RemoveAsync(string key)
        {
            var role = await roleManager.FindByIdAsync(key);

            if (role == null)
            {
                return new RoleDto
                {
                    Errors = new string[] { $"Unable to find role with id = {key}" }
                };
            }

            var accessorId = httpContextAccessor.HttpContext.GetUserId();
            var accessor = await userManager.FindByIdAsync(accessorId);

            var accessorRoles = await userManager.GetRolesAsync(accessor);

            var accessorRanks = roleManager.Roles.Where(x => x.AssociationId == accessor.AssociationId && accessorRoles.Contains(x.Name))
                .Select(x => x.Rank).ToList();

            var checkRank = false;
            
            foreach (var accessorRank in accessorRanks)
            {
                checkRank = !(accessorRank < role.Rank);
                if (checkRank == false)
                {
                    break;
                }
            }

            if(checkRank)
            {
                return new RoleDto
                {
                    Errors = new string[] { $"Unable to delete role with id {key} due to higher rank policy" }
                };
            }

            if (role.Name == AllowedRoles.Super)
            {
                return new RoleDto
                {
                    Errors = new string[] { $"Unable to delete Super role with id == {key}" }
                };
            }

            await roleManager.DeleteAsync(role);

            //foreach (var roleClaim in await roleManager.GetClaimsAsync(role))
            //{
            //    await roleManager.RemoveClaimAsync(role, roleClaim);
            //}



            //var result = await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));

            //if (!result.Succeeded)
            //{
            //    return new UserDto
            //    {
            //        Errors = result.Errors.Select(x => x.Description).ToArray()
            //    };
            //}

            //user.Deleted = true;

            //result = await userManager.UpdateAsync(user);

            //if (!result.Succeeded)
            //{
            //    return new UserDto
            //    {
            //        Errors = result.Errors.Select(x => x.Description).ToArray()
            //    };
            //}

            return mapper.Map<RoleDto>(role);
        }
    }
}
