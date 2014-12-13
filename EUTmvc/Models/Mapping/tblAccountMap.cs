using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblAccountMap : EntityTypeConfiguration<tblAccount>
    {
        public tblAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Account)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PassWord)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Image)
                .HasMaxLength(50);

            this.Property(t => t.EmailCode)
                .HasMaxLength(16);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblAccount");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Account).HasColumnName("Account");
            this.Property(t => t.PassWord).HasColumnName("PassWord");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.EmailCode).HasColumnName("EmailCode");
            this.Property(t => t.StatusAccountId).HasColumnName("StatusAccountId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.NewTime).HasColumnName("NewTime");
            this.Property(t => t.GroupAcountId).HasColumnName("GroupAcountId");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasRequired(t => t.tblGroupAcount)
                .WithMany(t => t.tblAccounts)
                .HasForeignKey(d => d.GroupAcountId);
            this.HasRequired(t => t.tblPerson)
                .WithMany(t => t.tblAccounts)
                .HasForeignKey(d => d.PersonId);
            this.HasRequired(t => t.tblStatusAccount)
                .WithMany(t => t.tblAccounts)
                .HasForeignKey(d => d.StatusAccountId);

        }
    }
}
