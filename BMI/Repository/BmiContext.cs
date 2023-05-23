using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIApp.Repository
{
    internal class BmiContext:DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<BMI> Bmis { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BMI;Trusted_Connection=True;; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Person>(p => {
                p.ToTable("Person");
                p.HasKey(a=>a.IDperson);
                p.Property(a=>a.Name);
                p.Property(a => a.LastName);
                p.Property(a => a.Telephon);
                p.Property(a => a.CodeMeli).IsRequired();
                p.Property(a => a.Age);
            });

            modelBuilder.Entity<BMI>(b => {
                b.ToTable("BMI");
                b.HasKey(a => a.IDBmi);
                b.Property(a => a.DateTime).IsRequired();
                b.Property(a => a.Weight).IsRequired();
                b.Property(a => a.height).IsRequired();
                b.Property(a => a.bmi);

                b.HasOne(a => a.Person).WithMany(b => b.bmi).HasForeignKey(c => c.Idpersons);
            
            });
            base.OnModelCreating(modelBuilder);
        }


    }
}
