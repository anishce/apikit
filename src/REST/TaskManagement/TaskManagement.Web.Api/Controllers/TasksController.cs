// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnishCeDev.TaskManagement.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskAppService taskAppService;
        public TasksController(TaskAppService taskAppService)
        {
            this.taskAppService = taskAppService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new string[] { "value1", "value2" };
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
        public async Task<IActionResult> Post([FromBody] string value)
        {
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
