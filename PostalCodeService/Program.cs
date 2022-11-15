using Microsoft.OpenApi.Models;
using PostalCodeService.Configuration;
using PostalCodeService.Respositories;
using PostalCodeService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Postal Codes Service",
        Description = "Postal Services for Tecnologi Seminar",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Technology Seminar Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Intelligent Machine License",
            Url = new Uri("https://example.com/license")
        }
    });
});

// Add services to the container.
builder.Services.Configure<PostalCodeStoreDatabase>(
    builder.Configuration.GetSection("PostalCodeStoreDatabase"));

builder.Services.AddTransient<IPostalCodeRepositories, PostalCodeRepositories>();
builder.Services.AddTransient<IPostalCodeService, PostalCodeService.Services.PostalCodeService>();

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
