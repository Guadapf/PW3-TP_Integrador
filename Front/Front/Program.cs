using Entidades;
using Servicio;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IEmpleadoService, EmpleadoService>();
//builder.Services.AddSingleton<IEmpleadoService, EmpleadoService>( x =>
//    new Service(x.GetRequiredService<IHttpClientFactory>(),
//                ""));
//builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
//builder.Services.AddSingleton<IEmpleadoService, EmpleadoService>(x =>
//    new Service(
//        services.BuildServiceProvider().GetService<IHttpClientFactory>(),
//        ""));

//builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
//builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
//services.AddTransient<Checkout>(new Checkout());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
