using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Repositories;
using Love4AnimalsApi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN DE SERVICIOS BASE ---

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Generador OpenAPI (.NET 9/10)

// --- 2. CONFIGURACIÓN DE BASE DE DATOS (POSTGRESQL) ---
// Esto le enseña a la API cómo conectar la interfaz con la clase real
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// --- 3. REGISTRO DE DEPENDENCIAS (INYECCIÓN DE DEPENDENCIAS) ---

// IMPORTANTE: Todos deben ser AddScoped para poder usar el AppDbContext.
// Se registra primero la Interfaz y luego la Clase que la implementa.

// Repositorios (Capa de datos)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Servicios (Capa de lógica de negocio)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

// --- 4. PIPELINE DE PETICIONES HTTP ---

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Love4Animals API - Documentación")
               .WithTheme(ScalarTheme.DeepSpace)
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();