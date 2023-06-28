using Microsoft.EntityFrameworkCore;
using TrabajoFinal.Models;
using TrabajoFinal.Servicios;

using Microsoft.AspNetCore.Authentication.Cookies;
using TrabajoFinal.Servicios.Contrato;
using TrabajoFinal.Servicios.Implementacion;

using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<TrabajofinalContext>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>   
    {
        options.LoginPath = "/Usuario/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

builder.Services
    .Add(new ServiceDescriptor(typeof(IDesayuno),
        new DesayunoRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IAlmuerzos),
        new AlmuerzosRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(ICenas),
        new CenasRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(ISnacks),
        new SnacksRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(IUtiles),
        new UtilesRepository()));

builder.Services
    .Add(new ServiceDescriptor(typeof(ITemporalVenta),
        new TemporalVentaRepository()));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TrabajoFinal}/{action=Index}/{id?}");

app.Run();