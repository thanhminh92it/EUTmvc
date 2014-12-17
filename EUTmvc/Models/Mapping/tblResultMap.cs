using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblResultMap : EntityTypeConfiguration<tblResult>
    {
        public tblResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Answer)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("tblResult");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.ExamQuestionId).HasColumnName("ExamQuestionId");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.ExecutionTime).HasColumnName("ExecutionTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Point).HasColumnName("Point");

            // Relationships
            this.HasOptional(t => t.tblAccount)
                .WithMany(t => t.tblResults)
                .HasForeignKey(d => d.AccountId);
            this.HasOptional(t => t.tblExamQuestion)
                .WithMany(t => t.tblResults)
                .HasForeignKey(d => d.ExamQuestionId);

        }
    }
}
