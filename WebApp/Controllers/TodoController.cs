using System;
using Data.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _todoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _todoService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<TodoController>
        [HttpPost]
        public void Post([FromBody] Todo entry)
        {
            try
            {
                _todoService.Insert(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Todo entry)
        {
            try
            {
                _todoService.Update(id, entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _todoService.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<TodoController>/MarkDone/5
        [HttpGet("{id}")]
        public IActionResult MarkDone(int id)
        {
            try
            {
                var result = _todoService.MarkDone(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<TodoController>/SetPercentComplete
        [HttpPost("/SetPercentComplete")]
        public IActionResult SetPercentage([FromBody]SetTodoPercentCompleteDto setTodoPercentCompleteDto)
        {
            try
            {
                var result = _todoService.SetTodoPercentComplete(setTodoPercentCompleteDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<TodoController>/GetIncomingTodo
        [HttpGet("/GetIncomingTodo")]
        public IActionResult GetIncomingTodo(IncomingType incomingType)
        {
            try
            {
                var result = _todoService.GetIncomingTodo(incomingType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
