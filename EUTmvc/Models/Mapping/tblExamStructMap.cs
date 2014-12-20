using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblExamStructMap : EntityTypeConfiguration<tblExamStruct>
    {
        public tblExamStructMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblExamStruct");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FormId).HasColumnName("FormId");
            this.Property(t => t.GradeId).HasColumnName("GradeId");
            this.Property(t => t.EasyNumber).HasColumnName("EasyNumber");
            this.Property(t => t.AverageNumber).HasColumnName("AverageNumber");
            this.Property(t => t.HardNumber).HasColumnName("HardNumber");
            this.Property(t => t.CategoryNumber).HasColumnName("CategoryNumber");
            this.Property(t => t.QuestionNumber).HasColumnName("QuestionNumber");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Request).HasColumnName("Request");
            this.Property(t => t.SubtestId).HasColumnName("SubtestId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasOptional(t => t.tblForm)
                .WithMany(t => t.tblExamStructs)
                .HasForeignKey(d => d.FormId);

        }
    }
}
