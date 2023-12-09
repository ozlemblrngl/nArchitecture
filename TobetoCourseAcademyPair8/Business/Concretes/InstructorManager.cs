using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Response;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        IInstructorDal _instructorDal;

        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public async Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest)
        {
            Instructor instructor = new Instructor();
            instructor.Id = Guid.NewGuid();
            instructor.FirstName = createInstructorRequest.FirstName;
            instructor.LastName = createInstructorRequest.LastName;
            Instructor createdInstructor = await _instructorDal.AddAsync(instructor);

            CreatedInstructorResponse createdInstructorResponse = new CreatedInstructorResponse();
            createdInstructorResponse.Id = createdInstructor.Id;
            createdInstructorResponse.FirstName = createdInstructor.FirstName;
            createdInstructorResponse.LastName = createdInstructor.LastName;

            return createdInstructorResponse;
        }

        public async Task<IPaginate<CreatedInstructorResponse>> GetListAsync()
        {
           var result = await _instructorDal.GetListAsync();
           return result;
        }
    }
}
