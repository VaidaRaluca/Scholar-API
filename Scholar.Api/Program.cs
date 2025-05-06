using Microsoft.EntityFrameworkCore;
using Scholar.Core.Interfaces;
using Scholar.Database.Context;
using Scholar.Database.Repos;
using Scholar.Database.Services;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<ScholarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



