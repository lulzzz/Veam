using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Veam.Services;

namespace Veam.Infra.Emails
{
    public static class EmailBootStrap
    {
        public static IServiceCollection AddCustomEmailService(this IServiceCollection services, IConfiguration Configuration)
        {
            // Add email services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IEmailService, EmailService>();

            // Get SendGrid configuration options
            services.Configure<SendGridOptions>(Configuration.GetSection("SendGridOptions"));

            // Get SMTP configuration options
            services.Configure<SmtpOptions>(Configuration.GetSection("SmtpOptions"));

            return services;
        }
    }
}
