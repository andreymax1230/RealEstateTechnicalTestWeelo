using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RealEstateTechnicalTest.Application.Common;
using RealEstateTechnicalTest.Application.Owner.Queries;
using RealEstateTechnicalTest.Application.Property.Commands;
using RealEstateTechnicalTest.Application.Property.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RealEstateTechnicalTest.Application
{
    public static class RegisterDependency
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(OwnerQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreatePropertyCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePropertyCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePricePropertyCommandHandle).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(QueryPropertyFilterHandler).GetTypeInfo().Assembly);
            return services;
        }
    }
}
