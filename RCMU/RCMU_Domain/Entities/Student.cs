using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RCMU_Domain.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }
        [MaxLength(50,ErrorMessage ="First Name cannot be longer than 50 character")]
        [Column("FirstName")]
        [Required]
        public string FirstMidName { get; set; }
        [DisplayFormat (DataFormatString ="{0:d}",ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public  string FullName
        {
            get { return FirstMidName + "," + LastName; }
        }
        public virtual ICollection<Enrollment> Enrollments{ get; set; }


    }
}
