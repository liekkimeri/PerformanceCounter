﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PerformanceCounterWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PerformanceCounterEntities : DbContext
    {
        public PerformanceCounterEntities()
            : base("name=PerformanceCounterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DriveInfo> DriveInfoes { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
    }
}
