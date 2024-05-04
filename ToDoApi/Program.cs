using CRMSDL.Abstract;
using CRMSDL.Repository;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Compact;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console(new RenderedCompactJsonFormatter())
            .WriteTo.Debug().WriteTo.File(@"Log\CRMSlog.txt", rollingInterval: RollingInterval.Day).CreateLogger();



        builder.Services.AddControllers();


        builder.Services.AddTransient<IUserDetailsDL, UserDetailsDL>();
        builder.Services.AddTransient<IProductDL, ProductsDetails>();
        builder.Services.AddTransient<ICart, CartDL>();
        builder.Services.AddTransient<ICart, CartDL>();
        builder.Services.AddTransient<IInvoice, InvoiceDL>();
        builder.Services.AddTransient<IPassword, PasswordDl>();
        //builder.Services.AddScoped<IUserDetails, UserDetailsBl>();



        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
   Host.CreateDefaultBuilder(args)
   .UseSerilog()
   .ConfigureWebHostDefaults(webBuilder =>
   {
       webBuilder.UseStartup<StartupBase>();
   });

}