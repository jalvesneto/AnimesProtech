using AnimesProtech.DAL.DAO;
using AnimesProtech.DAL.Models;
using AnimesProtech.MANAGER;
using AnimesProtech.MANAGER.Interfaces;
using AnimesProtech.REPOSITORY;
using AnimesProtech.REPOSITORY.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAnimeManager, AnimeManager>();
builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<IDirectorManager, DirectorManager>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IDAO<Anime>, AnimeDAO>();
builder.Services.AddScoped<IDAO<Director>, DirectorDAO>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .WithMethods("PUT", "DELETE", "GET", "POST")
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
