//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPTDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_service()
        {
            this.tb_service_log = new HashSet<tb_service_log>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string ipv4 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_service_log> tb_service_log { get; set; }
    }
}
