using Api;
using Infrastructure.DependencyInjection;
using Infrastructure.Identity;
using Application.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Map minimal API endpoints
Api.Endpoints.AuthEndpoints.MapAuthEndpoints(app);
Api.Endpoints.LoginEndpoints.MapLoginEndpoints(app);

app.Run();
