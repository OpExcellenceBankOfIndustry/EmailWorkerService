using BOI_WorkerService;
using BOI_WorkerService.Models.ConfigurationModels;
using BOI_WorkerService.Services;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BOI_WorkerService.Persistence.Mail;
using BOI_WorkerService.Repository.Mail;
using BOI_WorkerService.Repository;
using BOI_WorkerService.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddDbContext<BOIDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("BOIApplicationConnectionString"));
        });
       
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IEmailAttachmentRepository, EmailAttachmentRepository>();
        services.AddHostedService<Worker>();
        services.Configure<ServiceConfigurationSettings>(configuration.GetSection("ServiceConfigurationSettings"));
        services.Configure<EmailConfigurationSettings>(configuration.GetSection("EmailSettings"));
    })
    .UseSerilog(Logging.ConfigureLogger)
    .UseWindowsService()
    .Build();

await host.RunAsync();
