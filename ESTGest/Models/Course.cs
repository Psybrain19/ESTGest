//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESTGest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        public Course()
        {
            this.CourseClasses = new HashSet<CourseClass>();
            this.Disciplines = new HashSet<Discipline>();
            this.Users = new HashSet<User>();
        }
    
        public int c_id { get; set; }
        public string c_designation { get; set; }
        public int c_coursecat_id { get; set; }
    
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual ICollection<CourseClass> CourseClasses { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}