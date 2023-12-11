using Business.Dtos.Request;
using Business.Dtos.Requests;
using Business.Dtos.Requests.Course;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Business.Dtos.Responses.Course;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);
        Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest);
        Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest);
    }
}
