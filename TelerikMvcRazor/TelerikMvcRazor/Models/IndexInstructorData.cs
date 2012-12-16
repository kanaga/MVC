using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCMU_Domain.Entities;

namespace RCMU.Models
{
    public class IndexInstructorData
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }

    }

}

















