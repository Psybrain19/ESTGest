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
    
    public partial class CourseClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseClass()
        {
            this.Users = new HashSet<User>();
        }
    
        public int cc_id { get; set; }
        public string cc_designation { get; set; }
        public int cc_course_id { get; set; }
        public int cc_schedule_id { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Schedule Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
