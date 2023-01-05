using ASP.Net_Backend.Enums;
using ASP.Net_Backend.Models;
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
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorzed" })
            { StatusCode = StatusCodes.Status401Unauthorized };


            if (_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }
            var user = (User?)context.HttpContext.Items["User"];
            if (user == null || !_roles!.Contains(user.Role))
            {
                //to do, implement forbidden response
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
