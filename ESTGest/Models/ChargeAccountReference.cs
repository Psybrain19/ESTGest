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
    
    public partial class ChargeAccountReference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChargeAccountReference()
        {
            this.Users = new HashSet<User>();
        }
    
        public int car_id { get; set; }
        public string car_reference { get; set; }
        public int car_state { get; set; }
        public System.DateTime car_valtime { get; set; }
        public int car_amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
