using System.Text;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shortly.Authorization.API;
using Shortly.Authorization.BLL.Abstractions;
using Shortly.Authorization.BLL.Abstractions.Managers;
using Shortly.Authorization.BLL.Implementation;
using Shortly.Authorization.DAL.Abstractions;
using Shortly.Authorization.DAL.PostgreSQL;
using Shortly.Authorization.DAL.PostgreSQL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

var jwtSettings = builder.Configuration.GetSection(TokenConfiguration.PATH).Get<TokenConfiguration>()!;
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    }).AddCertificate(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
        };
    });

builder.Services
    .AddScoped<IAuthorizationStorage, AuthorizationStorage>()
    .AddScoped<IEntryStorage, EntryStorage>()
    .AddScoped<IAuthorizationManager, AuthorizationManager>()
    .AddScoped<IEntryManager, EntryManager>();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services
    .AddDbContext<IAuthorizationContext, AuthorizationContext>(x => x.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();