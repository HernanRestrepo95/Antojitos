﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AntojitosApiRest.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class antojitosEntities : DbContext
    {
        public antojitosEntities()
            : base("name=antojitosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TEST_CLIENTE> TEST_CLIENTE { get; set; }
        public virtual DbSet<TEST_FACTURA> TEST_FACTURA { get; set; }
        public virtual DbSet<TEST_FACTURA_DETALLE> TEST_FACTURA_DETALLE { get; set; }
        public virtual DbSet<TEST_PRODUCTO> TEST_PRODUCTO { get; set; }
    }
}
