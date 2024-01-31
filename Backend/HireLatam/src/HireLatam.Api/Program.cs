using HireLatam.Api.Extensions;
using HireLatam.Application;
using HireLatam.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .Infrastructue(builder.Configuration)
    .Application(builder.Configuration)
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option =>
{
    option.AddPolicy("web", c =>
    {
        c.WithOrigins("http://localhost:4200"); //FE URL
        c.AllowAnyHeader();
        c.AllowAnyMethod();
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("web");

app.Run();
