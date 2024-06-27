﻿using BillingApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Polly.Extensions.Http;
using Polly;
using BillingApi.Service.Interfaces;
using BillingApi.Service.Services;
using BillingApi.Infra.Exceptions;

namespace BillingApi.Infra.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataBase(configuration);
            services.AddHttpClient("HttpClient");
            services.AddHttpClient<IApiService, ApiService>().AddPolicyHandler(GetRetryPolicy());
            services.RegisterServices();
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillingAPI", Version = "v1" });
            });
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (outcome, timespan, retryAttempt, context) =>
                    {
                        Console.WriteLine($"Tentativa {retryAttempt} falhou. Esperando {timespan} antes da próxima tentativa.");
                    });
        }

        public static void ConfigurePipeline(this WebApplication app, IWebHostEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillingAPI v1"));
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            dataContext.Database.Migrate();
        }
    }
}