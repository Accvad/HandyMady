using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Web_proj_Backend.Data;
using Web_proj_Backend.Domain;

namespace Web_proj_Backend.Middleware
{
    public class ApiKey
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _scopeFactory;
        public ApiKey(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _next = next;
        }
        public async Task Invoke(HttpContext context, PersonContext personContext)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<DataContext>();
                var user = _context.Users.FirstOrDefault(x => x.Token == context.Request.Headers["ApiKey"]);
                if (user != null)
                {
                    personContext.UserId = user.Id;
                    personContext.ApiKey = context.Request.Headers["ApiKey"];
                }
                await _next.Invoke(context);
            }
            
        }
    }
}