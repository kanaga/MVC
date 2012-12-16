using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RCMU_Domain.Entities
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        [MaxLength(50)]
        [Display(Name="Office Location")]
        public String Location { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
