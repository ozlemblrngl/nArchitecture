using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Request
{
    public class CreateInstructorRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Course>? courses;
    }
}
