﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatWebsiteProjectCSharp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebChatEntities1 : DbContext
    {
        public WebChatEntities1()
            : base("name=WebChatEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<app_role> app_role { get; set; }
        public virtual DbSet<app_user> app_user { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<notify> notifies { get; set; }
        public virtual DbSet<relationship> relationships { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
