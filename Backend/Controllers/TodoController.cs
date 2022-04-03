using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Todo>>> Get([FromServices] DataContext context)
        {
            var todos = await context.Todos.ToListAsync();
            return todos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Todo>> GetById([FromServices] DataContext context, int id)
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        }
        
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Todo>> Post([FromServices] DataContext context, [FromBody] Todo todo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Todos.Add(todo);
            await context.SaveChangesAsync();
            return todo;
        }
    }
}