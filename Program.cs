using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using urbs.UseCases.GetTour;
using Urbs.Endpoints;
using Urbs.Models;
using Urbs.Services.ExtractJWTData;
using Urbs.Services.JWT;
using Urbs.Services.Profiles;
using Urbs.UseCases.CreateTour;
using Urbs.UseCases.EditTour;
using Urbs.UseCases.Login;

var builder = WebApplication.CreateBuilder(args);

// Conectando com o banco de dados.
builder.Services.AddDbContext<UrbsDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

// Configurar Serviços
builder.Services.AddTransient<IExtractJWTData, EFExtractJWTData>();
builder.Services.AddSingleton<IJWTService, JWTService>();
builder.Services.AddTransient<IProfilesService, EFProfileService>();


//Configurar UseCases
builder.Services.AddTransient<CreateTourUseCase>();
builder.Services.AddTransient<EditTourUseCase>();
builder.Services.AddTransient<GetTourUseCase>();
builder.Services.AddTransient<LoginUseCase>();


// Autenticação JWT

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

// Começo MAIN Config JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "ThePixeler", // Lembrar de Trocar o Nome
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });
    
// Fim MAIN Config JWT

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(); // Config JWT
builder.Services.AddAuthorization(); // Config JWT

var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();
app.ConfigureAuthEndpoints();
app.UseAuthentication(); // Config JWT
app.UseAuthorization(); // Config JWT


// Rodando!
app.Run();