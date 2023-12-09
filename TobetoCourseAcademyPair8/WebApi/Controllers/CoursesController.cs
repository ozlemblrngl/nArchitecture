using Business.Abstracts;
using Business.Dtos.Request;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result= await _courseService.Add(createCourseRequest);
            return Ok(result);
        }

        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetListAsync();
            return Ok(result);
        }

    }
}
