using AutoMapper;
using Business.Dtos.Request;
using Business.Dtos.Requests.Instructor;
using Business.Dtos.Response;
using Business.Dtos.Responses;
using Business.Dtos.Responses.Instructor;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    internal class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
            CreateMap<Paginate<Instructor>, Paginate<GetListInstructorResponse>>().ReverseMap();
            CreateMap<Instructor, GetListInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        }
    }
}
