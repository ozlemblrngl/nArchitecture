using Business.Dtos.Request;
using Business.Dtos.Requests;
using Business.Dtos.Requests.Instructor;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Business.Dtos.Responses.Instructor;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest);
    }
}
