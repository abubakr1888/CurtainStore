using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(IBaseService<Category> CategoryService, IMapper mapper) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Category.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken token)
        {
            var customer = mapper.Map<Category>(request);

            var response = await CategoryService.CreateAsync(customer, token);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpGet(ApiEndpoints.Category.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var departmentExist = await CategoryService.GetAsync(id, token);

            var response = mapper.Map<SingleCategoryResponse>(departmentExist);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet(ApiEndpoints.Category.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var departments = await CategoryService.GetAllAsync(token);

            var response = mapper.Map<IEnumerable<SingleCategoryResponse>>(departments);

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Category.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCategoryRequest? request,
            CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Category  category= await CategoryService.GetAsync(id, token);

            category.Name = request.Name;
           

            await CategoryService.UpdateAsync(category, token);

            var response = mapper.Map<SingleCategoryResponse>(category);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Category.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var response = await CategoryService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"category with ID {id} not found.");
        }
    }
}