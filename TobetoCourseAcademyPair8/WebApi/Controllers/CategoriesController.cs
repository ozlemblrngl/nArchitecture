using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Requests;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryRequest createCategoryRequest)
        {
            var result = await _categoryService.Add(createCategoryRequest); 
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
        {
            var result = await _categoryService.GetListAsync(pageRequest); 
            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _categoryService.Delete(deleteCategoryRequest);
            return Ok(result);
        }
    }
}
