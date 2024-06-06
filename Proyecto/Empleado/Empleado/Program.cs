using Empleado;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpleadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmpleadoDbConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmpleadoService, ServicioEmpleado>(); 

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
