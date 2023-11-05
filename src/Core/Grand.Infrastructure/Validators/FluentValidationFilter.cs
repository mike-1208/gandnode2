﻿using FluentValidation;
using Grand.SharedKernel.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Grand.Infrastructure.Validators
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        #region Fields

        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region Ctor

        public FluentValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called before the action executes, after model binding is complete
        /// </summary>
        /// <param name="context">A context for action filters</param>
        /// <param name="next"></param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //only in POST requests
            if (!HttpMethods.IsPost(context.HttpContext.Request.Method))
            {
                await next();
                return;
            }
            
            foreach (var argument in context.ActionArguments.Where(x => !CommonHelper.IsSimpleType(x.Value?.GetType())))
            {
                Type targetType = argument.Value!.GetType();
                Type[] implementedInterfaces = new[] { targetType }.Concat(targetType.GetInterfaces()).ToArray();
                foreach (Type interfaceType in implementedInterfaces)
                {
                    Type genericType = typeof(IValidator<>).MakeGenericType(interfaceType);
                    var validator = (IValidator)_serviceProvider.GetService(genericType);
                    if (validator is null)
                    {
                        continue;
                    }
                    var contextValidator = new ValidationContext<object>(argument.Value);
                    var result = await validator.ValidateAsync(contextValidator);
                    if (result.IsValid) continue;
                    foreach (var error in result.Errors)
                    {
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }

                var hasJsonData = context.HttpContext.Request.ContentType?.Contains("application/json") ?? false;
                if (!hasJsonData) continue;
                if (context.ModelState.IsValid) continue;
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
                
            }

            await next();
        }
        #endregion
    }
}