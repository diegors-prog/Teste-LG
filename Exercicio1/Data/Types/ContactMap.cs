using Exercicio1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exercicio1.Data.Types
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("contact");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.PhoneNumber)
                .HasColumnName("phone_number")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(i => i.RelationshipType)
                .HasColumnName("relationship_type")
                .IsRequired();

            builder.Property(i => i.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Contacts)
                .HasConstraintName("FK_Contact_Customer")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}