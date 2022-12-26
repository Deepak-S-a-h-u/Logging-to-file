using Emp_Dep_Dsg_Assignment.Data;
using Emp_Dep_Dsg_Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emp_Dep_Dsg_Assignment.Controllers
{
    [Route("api/Designation")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DesignationController> _logger;
        public DesignationController(ApplicationDbContext context,ILogger<DesignationController> logger)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDesignations()
        {
            return Ok(_context.Designations.ToList());
            _logger.LogInformation("GetDesignations called");
        }

        [HttpPost]
        public IActionResult AddDesignation([FromBody]Designation designation)
        {
           if(designation !=null && ModelState.IsValid)
            {
                _context.Designations.Add(designation);
                _context.SaveChanges();
                _logger.LogInformation("Designation is saved successfully");

                return Ok();
            }
            _logger.LogWarning("Model State is not Valid in Designation Save ");
            return BadRequest();
         }
       [HttpPut]
       public IActionResult UpdateDesignation([FromBody]Designation designation)
        {
            if(ModelState.IsValid)
            {
                _context.Designations.Update(designation);
                _context.SaveChanges();
                _logger.LogInformation("Designation is saved successfully");
                return Ok();
            }
            _logger.LogWarning("Model State is not Valid while Designation update");
            return BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult GetDesignation(int id)
        {
            var designationInDb = _context.Designations.Find(id);
            if (designationInDb == null)
                return NotFound();
            return Ok(designationInDb);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDesignation(int id)
        {
            var designationindb = _context.Designations.Find(id);
            if (designationindb != null)
            {
                _context.Designations.Remove(designationindb);
                _context.SaveChanges();
                _logger.LogInformation("Designation deleted successfully");
                return Ok();
            }
            _logger.LogWarning("No Designation found on selected/passed id");
            return NotFound();
        }
    }
}
