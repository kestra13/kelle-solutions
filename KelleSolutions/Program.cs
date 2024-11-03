using KelleSolutions.Data;
using KelleSolutions.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext with the SQL Server connection string
builder.Services.AddDbContext<KelleSolutionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Update Identity to use the custom User class (User instead of IdentityUser)
builder.Services.AddDefaultIdentity<User>() 
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KelleSolutionsDbContext>();

// Register IEmailSender and EmailSender services
builder.Services.AddTransient<IEmailSender, EmailSender>(); // Register the EmailSender service

// Add configuration for SendGrid email sending
builder.Services.Configure<SendGridOptions>(builder.Configuration.GetSection("SendGrid"));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
