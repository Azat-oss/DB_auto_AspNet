using DB_auto_AspNet.Pages.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Читаем строки подключения
string? conPostgres = builder.Configuration.GetConnectionString("Postgres");
string? conSQLite = builder.Configuration.GetConnectionString("SQLite");
string? conSqlExpress = builder.Configuration.GetConnectionString("SqlExpress");

// Читаем, какую СУБД использовать
string? activeDb = builder.Configuration["ActiveDatabase"] ?? "Postgres";

// Регистрируем ApplicationContext в зависимости от выбранной СУБД
switch (activeDb)
{
    case "Postgres":
        if (string.IsNullOrEmpty(conPostgres))
            throw new InvalidOperationException("Строка подключения 'Postgres' не задана.");
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(conPostgres));
        break;

    case "SQLite":
        if (string.IsNullOrEmpty(conSQLite))
            throw new InvalidOperationException("Строка подключения 'SQLite' не задана.");
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlite(conSQLite));
        break;

    case "SqlExpress":
        if (string.IsNullOrEmpty(conSqlExpress))
            throw new InvalidOperationException("Строка подключения 'SqlExpress' не задана.");
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(conSqlExpress)); 
        break;

    
}

// Добавляем контекст в DI-контейнер;
//builder.Services.AddDbContext<ApplicationContext>();
//builder.Services.AddDbContext<ApplicationContext>(options =>
//    options.UseNpgsql("Host=localhost;Port=5432;Database=VehicleDb;Username=postgres;Password=Passw0rd"));

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

app.MapRazorPages();

app.Run();
