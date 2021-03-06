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
    
    public partial class ACRA_RequestsI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACRA_RequestsI()
        {
            this.ACRA_R_TotalLiabilities = new HashSet<ACRA_R_TotalLiabilities>();
        }
    
        public long result_ID { get; set; }
        public string bid_numb { get; set; }
        public Nullable<System.DateTime> r_ans_date { get; set; }
        public Nullable<int> repres_type { get; set; }
        public string client_numb { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string passport { get; set; }
        public string soc_card { get; set; }
        public Nullable<int> r_objective { get; set; }
        public string address { get; set; }
        public Nullable<int> d_avilib { get; set; }
        public Nullable<int> residentity { get; set; }
        public Nullable<double> avrg_m_income { get; set; }
        public Nullable<System.DateTime> income_update_date { get; set; }
        public string employer { get; set; }
        public Nullable<int> req30_count { get; set; }
        public Nullable<int> req_count { get; set; }
        public Nullable<int> delay_tot { get; set; }
        public Nullable<int> delay_max { get; set; }
        public Nullable<int> overdue_tot { get; set; }
        public Nullable<double> c_overdue_sum { get; set; }
        public Nullable<int> fk_ov_curr_ID { get; set; }
        public Nullable<double> g_overdue_sum { get; set; }
        public Nullable<int> fk_gov_curr_ID { get; set; }
        public Nullable<int> covd_class_change { get; set; }
        public Nullable<int> data_err { get; set; }
        public string AppNumber { get; set; }
        public string ReportNumber { get; set; }
        public string IdCardNumber { get; set; }
        public string PersonBankruptIncome { get; set; }
        public string SwitchisClassQuantity { get; set; }
        public string InformationReviewDate { get; set; }
        public string TheWorstClassLoan { get; set; }
        public string SelfEnquiryQuantity30 { get; set; }
        public string SelfEnquiryQuantity { get; set; }
        public string DelayPaymentQuantity { get; set; }
        public string TheWorsClassGuarantee { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACRA_R_TotalLiabilities> ACRA_R_TotalLiabilities { get; set; }
    }
}
