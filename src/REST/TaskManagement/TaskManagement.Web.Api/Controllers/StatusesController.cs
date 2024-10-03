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
        private readonly ILogger logger;
#pragma warning disable VSSpell001 // Spell Check
        public StatusesController(IStatusAppService statusAppService, ILogger logger)
#pragma warning restore VSSpell001 // Spell Check
        {
            this.statusAppService = statusAppService;
            this.logger = logger;
        }

        // GET: api/status/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var status = await this.statusAppService.GetStatusAsync(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/status
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var statuses = await this.statusAppService.GetStatusesAsync();
                return Ok(statuses);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
