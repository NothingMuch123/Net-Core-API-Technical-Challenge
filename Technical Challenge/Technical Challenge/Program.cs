using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Technical_Challenge.DAL;
using Technical_Challenge.Databases;
using Technical_Challenge.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter Auth Key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication("basic").AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("basic", null);
builder.Services.AddHealthChecks();

// Self-created services
builder.Services.AddScoped<IUniversityDAL, UniversityDAL>();

// Database
builder.Services.AddDbContext<UniversityContext>(db => db.UseSqlite(builder.Configuration["DB"]));

var app = builder.Build();

// Trigger db migrations at the start
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UniversityContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
        dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Health check
app.UseHealthChecks("/");

app.UseAuthorization();

app.MapControllers();

app.Run();
