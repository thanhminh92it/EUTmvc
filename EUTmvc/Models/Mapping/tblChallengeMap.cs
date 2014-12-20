using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblChallengeMap : EntityTypeConfiguration<tblChallenge>
    {
        public tblChallengeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblChallenge");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.RivalId).HasColumnName("RivalId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.FormId).HasColumnName("FormId");
            this.Property(t => t.AccumulatedPoints).HasColumnName("AccumulatedPoints");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.ExamQuestionId).HasColumnName("ExamQuestionId");
            this.Property(t => t.ResultId).HasColumnName("ResultId");
            this.Property(t => t.ResultRivalId).HasColumnName("ResultRivalId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.tblCategory)
                .WithMany(t => t.tblChallenges)
                .HasForeignKey(d => d.CategoryId);
            this.HasOptional(t => t.tblExamQuestion)
                .WithMany(t => t.tblChallenges)
                .HasForeignKey(d => d.ExamQuestionId);
            this.HasOptional(t => t.tblForm)
                .WithMany(t => t.tblChallenges)
                .HasForeignKey(d => d.FormId);

        }
    }
}
