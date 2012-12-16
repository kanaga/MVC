using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RCMU_Domain.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        [MaxLength(50,ErrorMessage = "Title should not exceed more than 50 character len")]
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Credit is Required")]
        [Range(0,5,ErrorMessage = "Credit should be Between 0 to 5")]
        public int Credits { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
