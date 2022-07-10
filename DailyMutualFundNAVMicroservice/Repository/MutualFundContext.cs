using DailyMutualFundNAVMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyMutualFundNAVMicroservice.Repository
{
    public partial class MutualFundContext : DbContext
    {
        public MutualFundContext()
        {

        }
        public MutualFundContext(DbContextOptions<MutualFundContext> options) : base(options)
        {

        }
        public virtual DbSet<MutualFundDetails> MutualFundDetails { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=raghuram\\sqlexpress;Initial Catalog=Portfolio;Integrated Security=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MutualFundDetails>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.MutualFundId).HasColumnName("MutualFundId");

                entity.Property(e => e.MutualFundName).HasColumnName("MutualFundName");

                entity.Property(e => e.MutualFundValue).HasColumnName("MutualFundValue");


            });


        }

    }
}
