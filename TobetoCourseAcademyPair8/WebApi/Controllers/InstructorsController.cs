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
    public class InstructorsController : ControllerBase
    {
        IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] CreateInstructorRequest createInstructorRequest)
        {
           var result = await _instructorService.Add(createInstructorRequest);
            return Ok(result);
;        }

        [HttpGet]

        public async Task<IActionResult> GetList(PageRequest pageRequest)
        {
            var result = await _instructorService.GetListAsync(pageRequest);
            return Ok(result);
        }

    }
}
