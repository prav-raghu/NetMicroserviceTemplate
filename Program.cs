using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

builder.Services.AddDbContext<NetMicroserviceTemplate.Data.UserDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection"));
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // [1]
    
    app.UseSwaggerUI(options => {
     options.SwaggerEndpoint("/swagger/v1/swagger.json", "NetMicroserviceTemplate");
     options.RoutePrefix = string.Empty;
 });
}
app.UseAuthorization();
app.MapControllers();
app.Run();
