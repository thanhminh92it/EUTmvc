using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblTestResultMap : EntityTypeConfiguration<tblTestResult>
    {
        public tblTestResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Account)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblTestResults");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Account).HasColumnName("Account");
            this.Property(t => t.ExamQuestionId).HasColumnName("ExamQuestionId");
            this.Property(t => t.ExecutionTime).HasColumnName("ExecutionTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Point).HasColumnName("Point");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasRequired(t => t.tblExamQuestion)
                .WithMany(t => t.tblTestResults)
                .HasForeignKey(d => d.ExamQuestionId);

        }
    }
}
