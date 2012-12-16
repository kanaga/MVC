using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RCMU_Domain.Entities
{
   public  class Enrollment
    {
       public int EnrollmentID  { get; set; }
       public int CourseID { get; set; }
       public int StudentID { get; set; }
       [DisplayFormat(DataFormatString = "{0:#.#}",ApplyFormatInEditMode = true,NullDisplayText = "No Grade")]
       public Decimal? Grade { get; set; }
       public virtual Course Course { get; set; }
       public virtual Student Student { get; set; }

    }
}
