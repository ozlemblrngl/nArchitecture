using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Requests;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        IMapper _mapper;

        public CourseManager(ICourseDal courseDal, IMapper mapper)
        {
            _courseDal = courseDal;
            _mapper = mapper;
        }

        public async Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest)
        {
            Course course = _mapper.Map<Course>(createCourseRequest); // createCourseRequest'i course'a çevir.
            course.Id = Guid.NewGuid();

            await _courseDal.AddAsync(course);

            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(course); // course'u CreatedCourseRespponse'a çevir.
            return createdCourseResponse;

            // AutoMapping öncesi aşağıdaki gibi yazmamız gerekiyordu.

            // Course course = new Course();
            // course.Id = Guid.NewGuid();
            // course.Name = createCourseRequest.Name;
            // course.Price = createCourseRequest.Price;
            // course.Description = createCourseRequest.Description;
            // course.Category = createCourseRequest.Category;


            //Course createdCourse =  await _courseDal.AddAsync(course);
            // CreatedCourseResponse createdCourseResponse = new CreatedCourseResponse();
            // createdCourseResponse.Id = createdCourse.Id;
            // createdCourseResponse.Name = createdCourse.Name;
            // createdCourseResponse.Price = createdCourse.Price;
            // createdCourseResponse.Category = createdCourse.Category;
            // createdCourseResponse.Description = createdCourse.Description;

            // return createdCourseResponse; // mapping yaptığımız için artık ihtiyacımız yok buraya.

        }
        public async Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest)
        {

            var result= await _courseDal.GetListAsync(index:pageRequest.Index, size: pageRequest.Size );
            Paginate<GetListCourseResponse> response = _mapper.Map<Paginate<GetListCourseResponse>>(result);
            
            return response;

        }
    }
}
