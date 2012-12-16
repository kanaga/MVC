using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RCMU_Domain.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name is Required")]
        [MaxLength(50,ErrorMessage = "Department Name should not exceed more than 50 character")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Column(TypeName = "money")]
        public decimal? Budget { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Adminstrator")]
        public int? InstructorID { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual  Instructor Adminstrator { get; set; }



    }
}
