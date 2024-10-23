using GameApi.Application.Protocols.Db.Game;
using GameApi.Infrastructure.Db.Sqlite.Game;
using GameApi.Infrastructure.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
         builderCors=> builderCors.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IGameRepository, GameSqliteRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();