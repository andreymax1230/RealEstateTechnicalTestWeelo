using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateTechnicalTest.Application.Common;
using RealEstateTechnicalTest.Application.Owner.Queries;
using RealEstateTechnicalTest.Application.Property.Commands;
using RealEstateTechnicalTest.Domain.Repositories;
using RealEstateTechnicalTest.Domain.UnitOfWork;
using RealEstateTechnicalTest.Infraestructure;
using System.Reflection;

namespace RealEstateTechnicalTest.Api.Infraestructure
{
    public static class RegisterDependency
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddAutoMapper(typeof(Startup));
            return services;
        }
    }
}
