﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prakt19
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TennisRatingDB : DbContext
    {
        public TennisRatingDB()
            : base("name=TennisRatingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        private static TennisRatingDB context;
        public static TennisRatingDB GetContext()
        {
            if (context == null)
                context = new TennisRatingDB();
            return context;
        }
        public virtual DbSet<Rating> Rating { get; set; }
    }
}