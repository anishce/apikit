// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

// Ignore Spelling: App Anish Api

using AnishCeDev.TaskManagement.GraphQL.Api.ApplicationServices;
using AnishCeDev.TaskManagement.GraphQL.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnishCeDev.TaskManagement.GraphQL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppService categoryAppService;
        public CategoriesController(ICategoryAppService categoryAppService)
        {
            this.categoryAppService = categoryAppService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await categoryAppService.GetCategoriesAsync();

            return Ok(categories);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await categoryAppService.GetCategoryAsync(id);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryModel category)
        {
            await categoryAppService.AddCategoryAsync(category);

            return Created();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryModel category)
        {
            category.CategoryId = id;
            await categoryAppService.UpdateCategoryAsync(category);

            return Ok();
        }

        // PUT api/<CategoryController>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IEnumerable<CategoryModel> categories)
        {
            await categoryAppService.UpdateCategoriesAsync(categories);

            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryAppService.RemoveCategoryAsync(id);

            return Ok();
        }

        // PUT api/<CategoryController>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] IEnumerable<int> categoryIds)
        {
            await categoryAppService.RemoveCategoriesAsync(categoryIds);

            return Ok();
        }
    }
}
