using Csegurancacap7.Data;
using Csegurancacap7.Repositories;
using Csegurancacap7.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllers();
builder.Services.AddRazorPages();

// Configurar a conex�o com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar reposit�rios e servi�os
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<ISORepository, SORepository>();
builder.Services.AddScoped<ISOService, SOService>();

builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();
builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();

// Configurar a autentica��o JWT
var key = Encoding.ASCII.GetBytes("s3cr3tK3yForJWTs1gn1ng12345678901234"); // Nova chave secreta

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, // Validar o emissor
        ValidateAudience = true, // Validar o p�blico
        ValidateLifetime = true, // Validar o tempo de vida do token
        ValidateIssuerSigningKey = true, // Validar a chave de assinatura do emissor
        ValidIssuer = "your_issuer_here", // Configurar o emissor v�lido
        ValidAudience = "your_audience_here", // Configurar o p�blico v�lido
        IssuerSigningKey = new SymmetricSecurityKey(key) // Configurar a chave de assinatura
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Adicionar autentica��o
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
    