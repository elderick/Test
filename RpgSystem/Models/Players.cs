//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RpgSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Players()
        {
            this.Sheet = new HashSet<Sheet>();
        }
    
        public int Id { get; set; }
        public int IdCampaing { get; set; }
        public string usernick { get; set; }
        public string password { get; set; }
        public bool master { get; set; }
    
        public virtual Campaing Campaing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sheet> Sheet { get; set; }
    }
}
