using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Helpers.Attributes
{
    public class OwnerAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var errorStatusObject =
                new JsonResult(new { Message = "Unauthorized" });

            var tokenUser = (User?)context.HttpContext.Items["User"];
            var userId = (Guid?)context.HttpContext.Items["userId"];
            if (tokenUser == null)
            {
                errorStatusObject.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = errorStatusObject;
                return;
            }
            
            if (tokenUser.Id != userId)
            {
                errorStatusObject.StatusCode = StatusCodes.Status403Forbidden;
                context.Result = errorStatusObject;
            }
        }
    }
}
