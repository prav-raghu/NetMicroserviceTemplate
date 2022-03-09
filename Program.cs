var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
