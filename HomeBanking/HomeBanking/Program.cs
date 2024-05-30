using HomeBanking.Models;
using HomeBanking.Repositories;
using HomeBanking.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Add context to the container.

builder.Services.AddDbContext<HomeBankingContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("HomeBankingConexion")));

//Add repositories
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    //Obtenemos todos los services registrados en la App
    var services = scope.ServiceProvider;
    try
    {
        // Buscamos un service que este con la clase HomeBankingContext
        var context = services.GetRequiredService<HomeBankingContext>();
        DBInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ha ocurrido un error al enviar la información a la base de datos!");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
