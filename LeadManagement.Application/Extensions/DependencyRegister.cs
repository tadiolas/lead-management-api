using LeadManagement.Application.Commands.Generic.Create;
using LeadManagement.Application.Commands.Generic.Delete;
using LeadManagement.Application.Commands.Generic.Update;
using LeadManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeadManagement.Application.Extensions
{
    public static class DependencyRegister
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))

                .AddScoped<IRequestHandler<CreateEntityRequest<Category>>, CreateEntityHandler<Category>>()
                .AddScoped<IRequestHandler<CreateEntityRequest<AdditionalContact>>, CreateEntityHandler<AdditionalContact>>()
                .AddScoped<IRequestHandler<CreateEntityRequest<Customer>>, CreateEntityHandler<Customer>>()
                .AddScoped<IRequestHandler<CreateEntityRequest<Lead>>, CreateEntityHandler<Lead>>()

                .AddScoped<IRequestHandler<UpdateEntityRequest<Category>>, UpdateEntityHandler<Category>>()
                .AddScoped<IRequestHandler<UpdateEntityRequest<AdditionalContact>>, UpdateEntityHandler<AdditionalContact>>()
                .AddScoped<IRequestHandler<UpdateEntityRequest<Customer>>, UpdateEntityHandler<Customer>>()
                .AddScoped<IRequestHandler<UpdateEntityRequest<Lead>>, UpdateEntityHandler<Lead>>()

                .AddScoped<IRequestHandler<DeleteEntityRequest<Category>>, DeleteEntityHandler<Category>>()
                .AddScoped<IRequestHandler<DeleteEntityRequest<AdditionalContact>>, DeleteEntityHandler<AdditionalContact>>()
                .AddScoped<IRequestHandler<DeleteEntityRequest<Customer>>, DeleteEntityHandler<Customer>>()
                .AddScoped<IRequestHandler<DeleteEntityRequest<Lead>>, DeleteEntityHandler<Lead>>();
        }
    }
}
