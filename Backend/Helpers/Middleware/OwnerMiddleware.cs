namespace Backend.Helpers.Middleware
{
    public class OwnerMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public OwnerMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

            var userId = httpContext.Request.RouteValues["user"];

            if (userId != null)
            {
                httpContext.Items["UserId"] = userId;
            }
            await _nextRequestDelegate(httpContext);
        }
    }
}
