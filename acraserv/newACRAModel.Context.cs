﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class newACRAEntities : DbContext
    {
        public newACRAEntities()
            : base("name=newACRAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACRA_CreditScope> ACRA_CreditScope { get; set; }
        public virtual DbSet<ACRA_CreditStatus> ACRA_CreditStatus { get; set; }
        public virtual DbSet<ACRA_Loan_Types> ACRA_Loan_Types { get; set; }
        public virtual DbSet<ACRA_osDays> ACRA_osDays { get; set; }
        public virtual DbSet<ACRA_R_CurrentOverdue> ACRA_R_CurrentOverdue { get; set; }
        public virtual DbSet<ACRA_R_Loan> ACRA_R_Loan { get; set; }
        public virtual DbSet<ACRA_R_TotalLiabilities> ACRA_R_TotalLiabilities { get; set; }
        public virtual DbSet<ACRA_ReqStatus> ACRA_ReqStatus { get; set; }
        public virtual DbSet<ACRA_RequestsI> ACRA_RequestsI { get; set; }
        public virtual DbSet<ACRAUser> ACRAUsers { get; set; }
        public virtual DbSet<ACRA_TotalOfLnAndGr> ACRA_TotalOfLnAndGr { get; set; }
        public virtual DbSet<ACRA_Interrelated> ACRA_Interrelated { get; set; }
        public virtual DbSet<ACRA_RequestesInfo> ACRA_RequestesInfo { get; set; }
    }
}