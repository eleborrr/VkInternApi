using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using VkInternApi.Data;
using VkInternApi.Data.Repositories;
using VkInternApi.Data.Repositories.UserRep;
using VkInternApi.Services.Auth;
using VkInternApi.Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthorizationService>(BasicAuthenticationDefaults.AuthenticationScheme,
        null);
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("VkInternDB")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();