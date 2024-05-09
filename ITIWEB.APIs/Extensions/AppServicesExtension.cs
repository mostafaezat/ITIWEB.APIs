using Core.Repositories;
using ITIWEB.APIs.Helpers;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository;
using StackExchange.Redis;
using Microsoft.EntityFrameworkCore;
using ITIWEB.APIs.Errors;

namespace ITIWEB.APIs.Extensions
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection service) 
        {
             service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
             service.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            //old way
            // service.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));
             service.AddAutoMapper(typeof(MappingProfiles));

             service.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                                    .SelectMany(M => M.Value.Errors)
                                    .Select(E => E.ErrorMessage)
                                    .ToArray();
                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);

                };
            });
            return service;
        }
    }
}
