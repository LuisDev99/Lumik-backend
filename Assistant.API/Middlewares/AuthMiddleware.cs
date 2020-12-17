using Assistant.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Chat.API.Middlewares
{
    public class AuthMiddleware : IMiddleware
    {
        private readonly IUserService _userService;

        public AuthMiddleware(IUserService userService)
        {
            _userService = userService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Check if the request is from a trusted BOT
            var isTrustedSource = context.Request.Headers.ContainsKey("#BOT_BACKDOOR");

            // If it is, let him have FULL ACCESS
            if (isTrustedSource)
            {
                await next(context);
                return;
            }

            // Check if the headers contains key email
            var isValidRequest = context.Request.Headers.ContainsKey("#email");

            if (!isValidRequest)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Not authorized. (Missing header)");
                return;
            }

            // Grab the user email
            var email = context.Request.Headers["#email"];

            // Check if the user's email exists in the database
            var user = _userService.GetUserByEmail(email).Result;            

            if(user == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Not Authorized");
                return;
            }

            await next(context);
        }       
    }
}
