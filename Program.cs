using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    app.UseSwaggerUI(c => {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetMicroserviceTemplate");
     c.RoutePrefix = "documentation";
 });
}
app.UseAuthorization();
app.MapControllers();
app.Run();
