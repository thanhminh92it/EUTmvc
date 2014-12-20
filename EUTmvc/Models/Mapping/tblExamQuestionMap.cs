using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblExamQuestionMap : EntityTypeConfiguration<tblExamQuestion>
    {
        public tblExamQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Title)
                .HasMaxLength(200);

            this.Property(t => t.QuestionId)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblExamQuestion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ExamStructId).HasColumnName("ExamStructId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.AccumulatedPoints).HasColumnName("AccumulatedPoints");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasRequired(t => t.tblExamStruct)
                .WithMany(t => t.tblExamQuestions)
                .HasForeignKey(d => d.ExamStructId);

        }
    }
}
