using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblStructContentMap : EntityTypeConfiguration<tblStructContent>
    {
        public tblStructContentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblStructContent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StructId).HasColumnName("StructId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.EasyNumber).HasColumnName("EasyNumber");
            this.Property(t => t.AverageNumber).HasColumnName("AverageNumber");
            this.Property(t => t.DifficultNumber).HasColumnName("DifficultNumber");
            this.Property(t => t.CategoryNumber).HasColumnName("CategoryNumber");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasRequired(t => t.tblCategory)
                .WithMany(t => t.tblStructContents)
                .HasForeignKey(d => d.CategoryId);
            this.HasRequired(t => t.tblStruct)
                .WithMany(t => t.tblStructContents)
                .HasForeignKey(d => d.StructId);

        }
    }
}
