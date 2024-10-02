// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: App Anish Api

using AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnishCeDev.TaskManagement.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrioritiesController : ControllerBase
    {
        private readonly IPriorityAppService priorityAppService;

        public PrioritiesController(IPriorityAppService priorityAppService)
        {
            this.priorityAppService = priorityAppService;
        }

        // GET: api/<PriorityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var priorities = await priorityAppService.GetPrioritiesAsync();
            return Ok(priorities);
        }

        // GET api/<PriorityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var priority = await this.priorityAppService.GetPriorityAsync(id);

            return Ok(priority);
        }
    }
}
