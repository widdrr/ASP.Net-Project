using ASP.Net_Backend.Helpers.Authorization;
using ASP.Net_Backend.Services;

namespace ASP.Net_Backend.Helpers.Middleware
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtility jwtUtility)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = jwtUtility.ValidateToken(token!);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = await userService.GetByIdAsync(userId);
            }

            await _nextRequestDelegate(httpContext);
        }

    }
}
