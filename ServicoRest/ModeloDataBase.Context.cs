﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicoRest
{
    using System;
    using System.Data.Entity;
    //using System.Data.Entity.Infrastructure;
    
    public partial class ServicoRestDbContext : DbContext
    {
        public ServicoRestDbContext()
            : base("name=ServicoRestDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new Exception();
        }
    
        public virtual DbSet<Alunos> Alunos { get; set; }
    }
}
