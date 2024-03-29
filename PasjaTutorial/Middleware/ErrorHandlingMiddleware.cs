﻿using Microsoft.AspNetCore.Http;
using PasjaTutorial.Exceptions;
using System;
using System.Threading.Tasks;

namespace PasjaTutorial.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}