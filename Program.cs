var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var employees = new List<EmployeeResource>() {
    new EmployeeResource(1, "Jackson", "Alberta", "Finance", DateTime.Parse("6/5/2007")),
    new EmployeeResource(2, "Bennett", "Alicia", "Human Resources", DateTime.Parse("4/15/2001")),
    new EmployeeResource(3, "Avent", "Donna", "Revenue", DateTime.Parse("4/20/2009")),
    new EmployeeResource(4, "Holder", "Duane", "Human Services", DateTime.Parse("8/15/2020"))
};

app.MapGet("/employees", () =>
{
    return employees
        .OrderBy(employee => employee.LastName)
        .ThenBy(employee => employee.FirstName)
        .Select(employee => new Employee()
        {
            LastName = employee.LastName,
            FirstName = employee.FirstName,
            Department = employee.Department
        });
})
.WithName("GetEmployees");

app.MapGet("/employees/{id}", (int id) =>
{
    return employees.Where(employee => employee.Id == id).FirstOrDefault();
})
.WithName("GetEmployee");

app.MapPost("/employees", (string LastName, string FirstName, string Department, DateTime HireDate) =>
{
    var id = employees.OrderByDescending(employee => employee.Id).First().Id + 1;
    employees.Add(new EmployeeResource(id, LastName, FirstName, Department, HireDate));
})
.WithName("AddEmployee");

app.Run();

record EmployeeResource(int Id, string LastName, string FirstName, string Department, DateTime HireDate);

public class Employee {
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Department { get; set; }
}