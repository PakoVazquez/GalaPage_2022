using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

//Soporte para global y local
builder.Services.AddLocalization(option => { option.ResourcesPath = "Recursos"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// configurar lenguaje
var lenguajesSoportados = new[] { "es", "en" };
var opcionesLocalizacion = new RequestLocalizationOptions()
                .SetDefaultCulture(lenguajesSoportados[0])
                .AddSupportedCultures(lenguajesSoportados)
                .AddSupportedUICultures(lenguajesSoportados);

app.UseRequestLocalization(opcionesLocalizacion);

app.MapRazorPages();

app.Run();
