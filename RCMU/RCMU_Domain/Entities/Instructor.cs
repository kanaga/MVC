using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCMU_Domain.Entities
{
    public class Instructor
    {
        public Int32 InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? HireDate { get; set; }

        public string FullName
        {
            get { return FirstMidName + "  " + LastName; }
        }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }

    }
}
