//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniProjectNew
{
    using System;
    using System.Collections.Generic;
    
    public partial class Policy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Policy()
        {
            this.Endorsements = new HashSet<Endorsement>();
        }
    
        public string PolicyNumber { get; set; }
        public Nullable<int> Customerno { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string Createid { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Updateid { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string InsuredName { get; set; }
        public Nullable<int> InsuredAge { get; set; }
        public string Nominee { get; set; }
        public string Relation { get; set; }
        public string PremiumPaymentFrequency { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endorsement> Endorsements { get; set; }
        public virtual InsuranceProduct InsuranceProduct { get; set; }
    }
}
