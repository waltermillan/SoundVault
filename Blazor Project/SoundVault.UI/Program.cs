using SoundVault.UI.Interfaces;
using SoundVault.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la aplicación
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

// Registrar el servicio GenresService
builder.Services.AddScoped<GenderService>(sp =>
{
    var client = sp.GetRequiredService<HttpClient>();
    client.BaseAddress = new Uri("https://localhost:44332/");
    return new GenderService(client);
});

builder.Services.AddScoped<AlbumService>(sp =>
{
    var client = sp.GetRequiredService<HttpClient>();
    client.BaseAddress = new Uri("https://localhost:44332/");
    return new AlbumService(client);
});

// Configurar el HttpClient para GenderService
builder.Services.AddHttpClient<IGenderService, GenderService>(
    client => { client.BaseAddress = new Uri("https://localhost:44332/"); });

// Configurar el HttpClient para AlbumService
builder.Services.AddHttpClient<IAlbumService, AlbumService>(
    client => { client.BaseAddress = new Uri("https://localhost:44332/"); });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowAll");


// Configuración del pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
