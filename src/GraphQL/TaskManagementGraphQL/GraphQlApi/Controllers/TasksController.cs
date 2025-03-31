// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices;
using AnishCeDev.TaskManagement.GraphQL.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnishCeDev.TaskManagement.GraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskAppService taskAppService;
        public TasksController(ITaskAppService taskAppService)
        {
            this.taskAppService = taskAppService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var task = await taskAppService.GetTaskAsync(0);

            return Ok(task);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Task Id.");
            }
            var task = await taskAppService.GetTaskAsync(id);
            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskModel task)
        {
            await taskAppService.AddNewTaskAsync(task);

            return Ok();
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskModel task)
        {
            await taskAppService.AddNewTaskAsync(task);

            return Ok();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
        }
    }
}
