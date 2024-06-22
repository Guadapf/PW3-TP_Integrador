using EmployeeService;
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

builder.Services.AddTransient<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddTransient<IEmpleadoService, ServicioEmpleado>();

builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();
builder.Services.AddTransient<IServicioGenero, ServicioGenero>();

builder.Services.AddTransient<IPaiRepository, PaiRepository>();
builder.Services.AddTransient<IServicioPai, ServicioPai>();

builder.Services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddTransient<IServicioDepartamento, ServicioDepartamento>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
