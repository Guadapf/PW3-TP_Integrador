using Microsoft.EntityFrameworkCore;
using Nomina;
using Repositorio;
using Servicio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NominaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NominaContext")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ISalarioBaseRepository, SalarioBaseRepository>();
builder.Services.AddTransient<ISalarioBaseService, SalarioBaseService>();
builder.Services.AddTransient<ICompensacionService, CompensacionService>();
builder.Services.AddTransient<ICompensacionRepository, CompensacionRepository>();
builder.Services.AddTransient<IAntiguedadService, AntiguedadService>();
builder.Services.AddTransient<IAntiguedadRepository, AntiguedadRepository>();

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
