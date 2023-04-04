using Newtonsoft.Json;
using UrlShortener;
using UrlShortener.Biz.AppService;
using UrlShortener.Biz.AppService.ShortUrlService;
using UrlShortener.Interfaces;

string environment = System.Diagnostics.Debugger.IsAttached ? ".Development" : string.Empty;

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile($"appsettings{environment}.json", optional: true, reloadOnChange: true)
        .Build();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddScoped<IServiceInvoker, ServiceInvoker>();
    builder.Services.AddScoped<IUrlManagmentHandler, ShortUrlHandler>();
    builder.Services.AddScoped<IUrlValidator, UrlValidator>();
    builder.Services.AddScoped<IUrlRequestBuilder, UrlRequestBuilder>();

    builder.Services.AddControllers()
        .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore); //null variables ignore

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Information);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddRouting(options => options.LowercaseUrls = true);


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
catch (Exception)
{
    throw;
}
