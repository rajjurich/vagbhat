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
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICommonService commonService;
        private readonly IMapper mapper;

        public RoleService(RoleManager<Role> roleManager
            , IHttpContextAccessor httpContextAccessor
            , ICommonService commonService
            , IMapper mapper)
        {
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.commonService = commonService;
            this.mapper = mapper;
        }

        public async Task<RoleDto> AddAsync(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);

            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
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
                roleManager.Roles.Where(x => x.Rank > 0)
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

            if (role.Name == AllowedRoles.Super)
            {
                return new RoleDto
                {
                    Errors = new string[] { $"Unable to delete Super role with id == {key}" }
                };
            }

            foreach (var roleClaim in await roleManager.GetClaimsAsync(role))
            {
                await roleManager.RemoveClaimAsync(role, roleClaim);
            }

            return mapper.Map<RoleDto>(role);
        }
    }
}
