using Emp_Dep_Dsg_Assignment.Data;
using Emp_Dep_Dsg_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_Dep_Dsg_Assignment.Controllers
{
    [Route("api/Department")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(ApplicationDbContext context,ILogger<DepartmentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDepartment()
        {
            _logger.LogInformation("GetDepartments Called ");
            return Json(_context.Departments.ToList());
     
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] Department department)
        {
            if (department != null && ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                _logger.LogInformation("AddDepartment Called");
                return Ok();
            }
            else
            {
                _logger.LogInformation("An error accured while adding department");
                _logger.LogError("An error accured while adding department");
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                _logger.LogInformation("Department is saved successfully");
                return Ok();
            }
            _logger.LogWarning("Model State is not Valid while Department update");
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var departmentindb = _context.Departments.Find(id);
            if (departmentindb != null)
            {
                _context.Departments.Remove(departmentindb);
                _context.SaveChanges();
                _logger.LogInformation("Department deleted successfully");
                return Ok();
            }
            _logger.LogWarning("No Department found on selected/passed id");

            return NotFound();
        }
    }
}
