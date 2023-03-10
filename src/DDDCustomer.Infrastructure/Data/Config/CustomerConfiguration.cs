using DDDCustomer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDCustomer.Infrastructure.Data.Config
{
    public class CustomerConfiguration
        : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo");
            builder.HasKey(t => t.CustomerId);
            builder.Property(t => t.CustomerId)
                .IsRequired()
                .HasColumnName("CustomerId")
                .HasColumnType("uniqueidentifier").ValueGeneratedNever();
            builder.Property(t => t.CustomerNumber)
                .IsRequired()
                .HasColumnName("CustomerNumber")
                .HasColumnType("int");
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250);
            builder.Property(t => t.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250);
            builder.Property(t => t.CreditLimit)
                .HasColumnName("CreditLimit")
                .HasColumnType("decimal(18,2)");
            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);
            builder.Property(t => t.DateCreated)
                .IsRequired()
                .HasColumnName("DateCreated")
                .HasColumnType("date");
            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("bit");
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasColumnType("bit");
        }
    }
}