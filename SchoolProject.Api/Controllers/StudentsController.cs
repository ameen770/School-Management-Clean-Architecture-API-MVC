using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/Student/List?$orderby=Name
        //[HttpGet("/Student/List")]
        [HttpGet(Router.StudentRouting.List)]
        [EnableQuery]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        
        // GET /api/Student/List/5
        //[HttpGet("/Student/{id}")]
        [HttpGet(Router.StudentRouting.GetByID)]
        [EnableQuery]
        public async Task<IActionResult> GetStudentList([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }

        // ==================================================


        /*// GET: api/Students
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetStudentList(ODataQueryOptions<SelectSome_1OfGetStudentListResponse> options)
        {
            var query = new GetStudentListQuery();
            var result = await _mediator.Send(query);
            var queryableResult = result.AsQueryable(); // Convert the List to IQueryable
            var pagedResult = options.ApplyTo(queryableResult);
            return Ok(pagedResult);
        }*/

        /*// GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Getstudents()
        {
          if (_context.students == null)
          {
              return NotFound();
          }
            return await _context.students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
          if (_context.students == null)
          {
              return NotFound();
          }
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudID)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.students == null)
          {
              return Problem("Entity set 'ApplicationDBContext.students'  is null.");
          }
            _context.students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.students == null)
            {
                return NotFound();
            }
            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.students?.Any(e => e.StudID == id)).GetValueOrDefault();
        }*/
    }
}
