using KelleSolutions.Data;
using KelleSolutions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;                 // encrypt and decrypt JSON file data

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext with the SQL Server connection string
builder.Services.AddDbContext<KelleSolutionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        // for future debugging
        .EnableSensitiveDataLogging() 
        .EnableDetailedErrors());

// Update Identity to use the custom User class (User instead of IdentityUser)
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KelleSolutionsDbContext>();

// Registers Razor Pages for UI Rendering
builder.Services.AddRazorPages();

// Allow frontend JavaScript send requests
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
    });

var app = builder.Build();

// **Run the migrations**
using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<KelleSolutionsDbContext>();
    context.Database.Migrate();
}

// **Ensure Roles Exist**
await EnsureRolesAsync(app.Services);

// **Import Property Data**
await ImportPropertyDataAsync(app.Services);

async Task EnsureRolesAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new List<string> { "Admin", "Agent", "Broker" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
            Console.WriteLine($"Role '{role}' added.");
        }
        else
        {
            Console.WriteLine($"Role '{role}' already exists. Skipping...");
        }
    }
}

async Task ImportPropertyDataAsync(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<KelleSolutionsDbContext>();

    try
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "properties.json");

        if (File.Exists(jsonPath))
        {
            var jsonData = await File.ReadAllTextAsync(jsonPath);
            var properties = JsonSerializer.Deserialize<List<Property>>(jsonData);

            if (!context.Properties.Any())
            {
                context.Properties.AddRange(properties);
                await context.SaveChangesAsync();
                Console.WriteLine("Property data imported successfully!");
            }
            else
            {
                Console.WriteLine("Properties already exist! Skipping import...");
            }
        }
        else
        {
            Console.WriteLine("JSON file not found! No data to import!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error importing properties: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
