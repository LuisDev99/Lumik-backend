using Chat.Core.Interfaces;
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
        private readonly IAssistantRepository _assistantRepository;

        public AuthMiddleware(IAssistantRepository assistantRepository)
        {
            _assistantRepository = assistantRepository;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {                            
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
            var user = await _assistantRepository.GetUserByEmail(email);

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
