using ChallengeMobills.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeMobills.Data.Mappings
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Date)
                .IsRequired()
                .HasColumnType("datetime2(7)");
            
            builder.Property(p => p.Description)
                .HasColumnType("varchar(1000)");
            
            builder.Property(p => p.IsPaid)
                .HasColumnType("bit");

            builder.ToTable("Expenses");
        }
    }
}