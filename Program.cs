global using ComputerStoreWebApi.Data;
global using ComputerStoreWebApi.Data.Services;
global using ComputerStoreWebApi.Data.ViewModel;
global using ComputerStoreWebApi.Data.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey

    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
//Add Authorization header
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

    });
//DB String
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<LoginService>();

//CORS POLICY
var MyAllowSpecificOrigin = "_myAllowSpecificOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigin, 
        builder =>
    {
        builder.WithOrigins("http://localhost:8080");
        builder.WithOrigins("http://127.0.0.1:5500");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppDbInitializer.Seed(app);

app.UseCors(MyAllowSpecificOrigin);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


