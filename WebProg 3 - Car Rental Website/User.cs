//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProg_3___Car_Rental_Website
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<short> UserType { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> DateReg { get; set; }
        public string LicenseNum { get; set; }
        public string salt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual UserType UserType1 { get; set; }
    }
}
