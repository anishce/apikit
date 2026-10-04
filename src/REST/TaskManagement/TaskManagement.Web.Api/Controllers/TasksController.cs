// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
using AnishCeDev.TaskManagement.Web.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnishCeDev.TaskManagement.Web.Api.Controllers
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
        public async Task<IEnumerable<TaskModel>> Get()
        {
            return await taskAppService.GetTasksAsync();
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
            return Created();
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TaskModel task)
        {
            await taskAppService.UpdateTaskAsync(id, task).ConfigureAwait(false);
            return Ok();
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await taskAppService.RemoveTaskAsync(id);
            return Ok();
        }
    }
}
