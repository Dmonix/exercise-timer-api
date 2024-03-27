using ExerciseTimer.API.Models;
using ExerciseTimer.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

builder.Services.Configure<TimerDatabaseSettings>(
    builder.Configuration.GetSection("TimerDatabase"));
// Add services to the container.

builder.Services.AddSingleton<TimersService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(cors => cors
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader());

app.MapControllers();

app.Run();
