using ComputerStoreWebApi.Data;
using ComputerStoreWebApi.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB String
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddTransient<AdminService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<TagService>();
builder.Services.AddTransient<ProductService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();


