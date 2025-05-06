using Microsoft.EntityFrameworkCore;
using ProniaBB209.DAL;
//using ProniaBB209.Services;
//builder.Services.AddSingleton<EmailService>();
//builder.Services.AddScoped<IEmailService, TestService>();
//builder.Services.AddTransient<EmailService>();


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt=>
{
    //opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

});



var app = builder.Build();


//admin

app.MapControllerRoute(
    "admin",
    "{area:exists}/{controller=home}/{action=index}/{id?}"
    );


//user

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"
    );
app.UseStaticFiles();
app.Run();


