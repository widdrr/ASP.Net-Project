using ASP.Net_Backend.Helpers.Authorization;

namespace ASP.Net_Backend.Helpers.Middleware
{
    public class JwtMiddleware
    {

        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUsersService usersService, IJwtUtility jwtUtility)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = jwtUtility.ValidateToken(token!);

            if (userId != Guid.Empty)
            {
                httpContext.Items["User"] = usersService.GetById(userId);
            }

            await _nextRequestDelegate(httpContext);
        }

    }
}
}
