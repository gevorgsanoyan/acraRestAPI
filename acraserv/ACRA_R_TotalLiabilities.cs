//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace acraserv
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACRA_R_TotalLiabilities
    {
        public long tot_l_ID { get; set; }
        public Nullable<long> fk_result_ID { get; set; }
        public Nullable<int> l_type { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<int> currID { get; set; }
    
        public virtual ACRA_RequestsI ACRA_RequestsI { get; set; }
    }
}
