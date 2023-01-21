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
            var userId = (string?)httpContext.Request.RouteValues["userId"];

            if (userId != null)
            {
                httpContext.Items["userId"] = new Guid(userId);
            }
            await _nextRequestDelegate(httpContext);
        }
    }
}
