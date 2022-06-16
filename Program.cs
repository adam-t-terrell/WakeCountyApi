using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WakeCountyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WakeCountyContext") ?? throw new InvalidOperationException("Connection string 'WakeCountyContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddDbContext<WakeCountyContext>(opt =>
    opt.UseInMemoryDatabase("EmployeeList"));
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WakeCountyApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();