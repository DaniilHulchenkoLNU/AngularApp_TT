using AngularApp_TT.Data;
using AngularApp_TT.Server.DAL.Implementations;
using AngularApp_TT.Server.DAL.Interfaces;
using AngularApp_TT.Server.Service;
using AngularApp_TT.Server.Services;
using AngularApp_TT.Server.Servise.Auth;
using AngularApp_TT.Server.Servise.Helpers;
using DAL.Implementations;
using DAL.Interfaces;
using GlassStore.Server.Servise.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().
        UseSqlServer(connectionString));

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped(typeof(iBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<iUserRepository, UserRepository>();
builder.Services.AddScoped<AuthServise>();
builder.Services.AddScoped<UserServise>();
builder.Services.AddHttpClient<CryptoService>();
builder.Services.AddScoped<HttpService>();

/*################################### Auth ##################################################*/
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Auth"));

var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = authOptions.Issuer,

            ValidateAudience = true,
            ValidAudience = authOptions.Audience,

            ValidateLifetime = true,

            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddHttpContextAccessor();
/*############################## localhost 4200 ######################################################*/
string[] WhiteListCors = builder.Configuration.GetSection("AngularUrl").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(WhiteListCors)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials(); // авторизація
        });
});
/*####################################################################################*/



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseCors();

app.Run();
