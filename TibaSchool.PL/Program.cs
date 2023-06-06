using TibaSchool.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using TibaSchool.BL.Mapper;
using TibaSchool.BL.Interface;
using TibaSchool.BL.Repository;
using TibaSchool.DAL.Entity;
using Newtonsoft.Json.Serialization;
using TibaSchool.BL.VModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add NewtonsoftJson For Ajax Format Problem.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(Opt =>
{
    Opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

// Add Connection String Configuration.
var connectionString = builder.Configuration.GetConnectionString("ConnectionStringApp");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

//Add Auto Mapper Services.
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

//Add DI Services.
builder.Services.AddScoped<IEvent, EventRep>();
builder.Services.AddScoped<IFolder, FolderRep>();
builder.Services.AddScoped<IAlbum, AlbumRep>();
builder.Services.AddScoped<IImages, ImagesRep>();
builder.Services.AddScoped<IVideoFolder, VideoFolderRep>();
builder.Services.AddScoped<IVideo, VideoRep>();

//Add Session.
/*builder.Services.AddSession();
builder.Services.AddScoped<IAccountRep, AccountRep>();*/

//Add Identity Configration.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
    });

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);


//Password and username Configration.
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Default Password settings.
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});/*AddEntityFrameworkStores<ApplicationDBContext>()*/

/*builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});*/

/****************************************************************************************************/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


//Add Session.
//app.UseSession();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
