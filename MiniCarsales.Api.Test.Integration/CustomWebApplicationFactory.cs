using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MiniCarsales.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniCarsales.Api.Test.Integration
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return base.CreateHostBuilder();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(IHostedService));

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                /*
                 * This is a work around given by the aspnetcore team regarding replacing DbContext with InMemory DB
                 * https://github.com/aspnet/AspNetCore/issues/13918#issuecomment-532162945
                 */
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<VehiclesContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddScoped(p =>
                DbContextOptionsFactory<VehiclesContext>(
                p,
                (sp, options) =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                }));             
            });
        }

        /// <summary>
        /// https://github.com/aspnet/AspNetCore/blob/master/src/Identity/test/Identity.FunctionalTests/Infrastructure/FunctionalTestsServiceCollectionExtensions.cs#L24-L55
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="applicationServiceProvider"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        private static DbContextOptions<TContext> DbContextOptionsFactory<TContext>(
            IServiceProvider applicationServiceProvider,
            Action<IServiceProvider, DbContextOptionsBuilder> optionsAction)
            where TContext : DbContext
        {
            var builder = new DbContextOptionsBuilder<TContext>(
                new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>()));

            builder.UseApplicationServiceProvider(applicationServiceProvider);

            optionsAction?.Invoke(applicationServiceProvider, builder);

            return builder.Options;
        }
    }
}
