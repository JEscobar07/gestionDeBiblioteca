using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using gestionBiblioteca.Filters; // Asegúrate de que el namespace es correcto
using gestionBiblioteca.Data;
using gestionBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Bfkxytwn9bgzdtfvozeuContext>(options =>{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConection"),Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"));
});

// Configurar servicios
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<VerifySession>(); // Registrar el filtro globalmente
});

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configurar la aplicación
app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
