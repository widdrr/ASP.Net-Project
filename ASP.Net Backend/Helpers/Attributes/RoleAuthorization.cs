using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models;
using ASP.Net_Backend.Models.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab4_13.Helpers.Attributes
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
