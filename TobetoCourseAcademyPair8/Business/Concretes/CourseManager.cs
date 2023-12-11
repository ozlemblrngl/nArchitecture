using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Requests;
using Business.Dtos.Requests.Course;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Business.Dtos.Responses.Course;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

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

            Course createdCourse = await _courseDal.AddAsync(course);

            CreatedCourseResponse createdCourseResponse = _mapper.Map<CreatedCourseResponse>(createdCourse); // createdCourse'u CreatedCourseResponse'a çevir.
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

        public async Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest)
        {
            Course course = await _courseDal.GetAsync(predicate: c => c.Id == deleteCourseRequest.Id);
            Course deletedCourse = await _courseDal.DeleteAsync(course);
            DeletedCourseResponse response = _mapper.Map<DeletedCourseResponse>(deletedCourse);
            return response;
        }

        public async Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest)
        {

            var result = await _courseDal.GetListAsync(
                index: pageRequest.Index,
                size: pageRequest.Size,
                include: p => p.Include(p => p.Category).Include(p => p.Instructor)
            );
            Paginate<GetListCourseResponse> response = _mapper.Map<Paginate<GetListCourseResponse>>(result);

            return response;

        }

        public async Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest)
        {
            Course course = await _courseDal.GetAsync(predicate: c => c.Id == updateCourseRequest.Id);
            course.Name = updateCourseRequest.Name;
            course.Description = updateCourseRequest.Description;
            course.Price = updateCourseRequest.Price;
            course.CategoryId = updateCourseRequest.CategoryId;
            course.ImageUrl = updateCourseRequest.ImageUrl;
            course.InstructorId = updateCourseRequest.InstructorId;

            Course createdCourse = await _courseDal.UpdateAsync(course);
            UpdatedCourseResponse response = _mapper.Map<UpdatedCourseResponse>(createdCourse);
            return response;

        }
    }
}
