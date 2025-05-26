using Microsoft.EntityFrameworkCore;
using Scholar.Core.Interfaces;
using Scholar.Database.Context;
using Scholar.Database.Repos;
using Scholar.Database.Services;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// added this 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddControllers();

builder.Services.AddDbContext<ScholarDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("Scholar.Database")
    ));


builder.Services.AddScoped<IStudentRepo, StudentRepo>(); builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IGradeRepo, GradeRepo>(); builder.Services.AddScoped<IGradeRepo, GradeRepo>();

builder.Services.AddScoped<IStudentService, StudentService>(); builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Scholar API",
        Version = "v1",
        Description = "School Related API"
    });
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scholar API V1");
        c.RoutePrefix = string.Empty;
    });
}

// here
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



