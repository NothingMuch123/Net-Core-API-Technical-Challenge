using Microsoft.EntityFrameworkCore;
using Technical_Challenge.DAL;
using Technical_Challenge.Databases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
