// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using AnishCeDev.TaskManagement.Web.Api.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable VSSpell001 // Spell Check
#pragma warning disable VSSpell001 // Spell Check
namespace AnishCeDev.TaskManagement.Web.Api.Controllers
#pragma warning restore VSSpell001 // Spell Check
#pragma warning restore VSSpell001 // Spell Check
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusAppService statusAppService;

#pragma warning disable VSSpell001 // Spell Check
        public StatusesController(IStatusAppService statusAppService)
#pragma warning restore VSSpell001 // Spell Check
        {
            this.statusAppService = statusAppService;    
        }

        // GET: api/status/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await this.statusAppService.GetStatusAsync(id);
            return Ok(status);
        }

        // GET: api/status
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var statuses = await this.statusAppService.GetStatusesAsync();
            return Ok(statuses);
        }
    }
}
