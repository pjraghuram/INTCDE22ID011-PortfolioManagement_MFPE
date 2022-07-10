using DailySharePriceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DailySharePriceApi.Repository
{
    public partial class StockContext : DbContext
    {
        public StockContext()
        {

        }
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {

        }
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
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

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId).HasColumnName("StockId");

                entity.Property(e => e.StockName).HasColumnName("StockName");

                entity.Property(e => e.StockValue).HasColumnName("StockValue");


            });


        }

    }
}
