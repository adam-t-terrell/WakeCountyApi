using Microsoft.EntityFrameworkCore;
using WakeCountyApi.Models;

    public class WakeCountyContext : DbContext
    {
        public WakeCountyContext (DbContextOptions<WakeCountyContext> options)
            : base(options)
        {
            EmployeeResource.AddRange(
                new List<EmployeeResource>() {
                    new EmployeeResource(1, "Jackson", "Alberta", "Finance", DateTime.Parse("6/5/2007")),
                    new EmployeeResource(2, "Bennett", "Alicia", "Human Resources", DateTime.Parse("4/15/2001")),
                    new EmployeeResource(3, "Avent", "Donna", "Revenue", DateTime.Parse("4/20/2009")),
                    new EmployeeResource(4, "Holder", "Duane", "Human Services", DateTime.Parse("8/15/2020"))
                });
        }

        public DbSet<EmployeeResource> EmployeeResource { get; set; } = null!;
    }
