using SchoolProject.Core;
using SchoolProject.Service;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependency Injection
builder.Services.AddInfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies();
#endregion

///
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
});
///


//Connection To SQL Server
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"));
});

var app = builder.Build();

///
app.UseCors("AllowSpecificOrigin");
///


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
