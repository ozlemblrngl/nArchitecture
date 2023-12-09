using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            Course course = new Course();
            course.Id = Guid.NewGuid();
            course.Name = createCourseRequest.Name;
            course.Price = createCourseRequest.Price;
            course.Description = createCourseRequest.Description;
            course.Category = createCourseRequest.Category;
            
           
           Course createdCourse =  await _courseDal.AddAsync(course);
            CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            createdCourseResponse.Id = createdCourse.Id;
            createdCourseResponse.Name = createCourseRequest.Name;
            createdCourseResponse.Price = createCourseRequest.Price;
            createdCourseResponse.Category = createCourseRequest.Category;
            createdCourseResponse.Description = createCourseRequest.Description;

            return createdCourseResponse;

        }

        public async Task<IPaginate<CreatedCourseResponse>> GetListAsync()
        {
            var result= await _courseDal.GetListAsync();
            return result;
        }
    }
}
