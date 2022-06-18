using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using VolunTEENProject.Models;
using VolunTEENProject.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IEndUserRepository, EndUserRepository>();
builder.Services.AddScoped<IOpportunityRepository, OpportunityRepository>();
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IFriendRepository, FriendRepository>();

builder.Services.AddIdentity<EndUser, IdentityRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequiredLength = 8;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireDigit = true;
//    options.User.RequireUniqueEmail = true;
//});

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
