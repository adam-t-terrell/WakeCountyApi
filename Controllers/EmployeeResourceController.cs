using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WakeCountyApi.Models;

namespace WakeCountyApi.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeeResourceController : ControllerBase
    {
        private readonly WakeCountyContext _context;

        public EmployeeResourceController(WakeCountyContext context)
        {
            _context = context;
        }

        // GET: employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.EmployeeResource == null)
            {
                return NotFound();
            }
            var employees = _context.EmployeeResource.OrderBy(employee => employee.LastName)
                .ThenBy(employee => employee.FirstName)
                .Select(employee => new Employee(employee.LastName, employee.FirstName, employee.Department));
            return await employees.ToListAsync();
        }

        // GET: employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResource>> GetEmployeeResource(int id)
        {
            if (_context.EmployeeResource == null)
            {
                return NotFound();
            }
            var employeeResource = await _context.EmployeeResource.FindAsync(id);

            if (employeeResource == null)
            {
                return NotFound();
            }

            return employeeResource;
        }

        // POST: employees
        [HttpPost]
        public async Task<ActionResult<EmployeeResource>> PostEmployeeResource(string LastName, string FirstName, string Department, DateTime HireDate)
        {
            if (_context.EmployeeResource == null)
            {
                return Problem("Entity set 'WakeCountyContext.EmployeeResource'  is null.");
            }

            var id = _context.EmployeeResource.OrderByDescending(employee => employee.Id).First().Id + 1;
            var employeeResource = new EmployeeResource(id, LastName, FirstName, Department, HireDate);
            _context.EmployeeResource.Add(employeeResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeResource", new { id = id }, employeeResource);
        }

        private bool EmployeeResourceExists(int id)
        {
            return (_context.EmployeeResource?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
