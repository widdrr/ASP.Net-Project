﻿using Backend.Enums;
using Backend.Models;
using Backend.Models.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Helpers.Attributes
{
    public class RoleAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public RoleAuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var errorStatusObject =
                new JsonResult(new { Message = "Unauthorized" });

            var user = (User?)context.HttpContext.Items["User"];
            if (_roles == null || user == null)
            {
                errorStatusObject.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = errorStatusObject;
                return;
            }

            if (!_roles!.Contains(user.Role))
            {
                errorStatusObject.StatusCode= StatusCodes.Status403Forbidden;
                context.Result = errorStatusObject;
            }
        }
    }
}
