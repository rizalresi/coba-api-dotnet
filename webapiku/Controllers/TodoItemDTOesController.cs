﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapiku.Models;

namespace webapiku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemDTOesController : ControllerBase
    {
        private readonly WebContext _context;

        public TodoItemDTOesController(WebContext context)
        {
            _context = context;
        }

        // GET: api/TodoItemDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItemDTO()
        {
            return await _context.TodoItemDTO.ToListAsync();
        }

        // GET: api/TodoItemDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItemDTO(long id)
        {
            var todoItemDTO = await _context.TodoItemDTO.FindAsync(id);

            if (todoItemDTO == null)
            {
                return NotFound();
            }

            return todoItemDTO;
        }

        // PUT: api/TodoItemDTOes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemDTO(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItemDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemDTOExists(id))
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

        // POST: api/TodoItemDTOes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItemDTO(TodoItemDTO todoItemDTO)
        {
            _context.TodoItemDTO.Add(todoItemDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItemDTO), new { id = todoItemDTO.Id }, todoItemDTO);
        }

        // DELETE: api/TodoItemDTOes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemDTO>> DeleteTodoItemDTO(long id)
        {
            var todoItemDTO = await _context.TodoItemDTO.FindAsync(id);
            if (todoItemDTO == null)
            {
                return NotFound();
            }

            _context.TodoItemDTO.Remove(todoItemDTO);
            await _context.SaveChangesAsync();

            return todoItemDTO;
        }

        private bool TodoItemDTOExists(long id)
        {
            return _context.TodoItemDTO.Any(e => e.Id == id);
        }
    }
}
