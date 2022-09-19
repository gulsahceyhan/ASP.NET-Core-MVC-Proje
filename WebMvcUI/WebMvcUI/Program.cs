using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


//using FluentValidation.DependencyInjectionExtensions;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("WebMvcUIContextConnection") ?? throw new InvalidOperationException("Connection string 'WebMvcUIContextConnection' not found.");


var userConnectionString = builder.Configuration["ConnectionStrings:WebMvcUIContextConnection"];

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Configuration
           .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
           .AddEnvironmentVariables();


UserCredential GetUserCredential( WebApplicationBuilder builder)
{
    var configSection = builder.Configuration.GetSection(nameof(UserCredential));

    var config = configSection.Get<UserCredential>();
   
    return config;
}

builder.Services.AddDbContext<Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:myConn"]);
});


builder.Services.AddTransient<ICategoryService, CategoryManager>();
builder.Services.AddTransient<ICategoryDal, CategoryRepository>();
builder.Services.AddTransient<IProductService, ProductManager>();
builder.Services.AddTransient<IProductDal, ProductRepository>();

builder.Services.AddTransient<IUserCredential, UserCredential>(t =>
{
    var UserCredential = GetUserCredential(builder);
    return UserCredential;
});
builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();


var app = builder?.Build();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
