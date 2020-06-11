using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SampleWebApi.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
        public virtual DbSet<GenerateLinkEntity> GenerateLink { get; set; }
       
 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenerateLinkEntity>()
                .Property(e => e.URL);
               
        }
        }
   
 }
