using Microsoft.Net.Http.Headers;
using TMDB.API.Mappings;
using TMDB.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("Tmdb", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Accept, "application/json");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Authorization, "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NTE2ZGZmZDBlOWZjNTIwYTQ1MzFjODBlOGYwN2JlNCIsInN1YiI6IjYyYzM5OWIzZjZmZDE4MDA3Y2ViYjE5OSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.vWuijyg5g7CaQC8LHcHfgbrEkpaX8fFn3UFDaKPRQVQ");
});

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
