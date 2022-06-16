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

var employees = new List<Employee>() {
    new Employee(1, "Jackson", "Alberta", "Finance", DateTime.Parse("6/5/2007")),
    new Employee(2, "Bennett", "Alicia", "Human Resources", DateTime.Parse("4/15/2001")),
    new Employee(3, "Avent", "Donna", "Revenue", DateTime.Parse("4/20/2009")),
    new Employee(4, "Holder", "Duane", "Human Services", DateTime.Parse("8/15/2020"))
};

app.MapGet("/employees", () =>
{
    return employees;
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
    employees.Add(new Employee(id, LastName, FirstName, Department, HireDate));
})
.WithName("AddEmployee");

app.Run();

record Employee(int Id, string LastName, string FirstName, string Department, DateTime HireDate);