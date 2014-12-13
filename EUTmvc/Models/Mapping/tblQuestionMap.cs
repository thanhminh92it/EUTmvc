using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblQuestionMap : EntityTypeConfiguration<tblQuestion>
    {
        public tblQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Code)
                .IsRequired();

            this.Property(t => t.Contents)
                .IsRequired();

            this.Property(t => t.Answer)
                .IsRequired();

            this.Property(t => t.AnswerA)
                .IsRequired();

            this.Property(t => t.AnswerB)
                .IsRequired();

            this.Property(t => t.AnswerC)
                .IsRequired();

            this.Property(t => t.AnswerD)
                .IsRequired();

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblQuestion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Contents).HasColumnName("Contents");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.AnswerA).HasColumnName("AnswerA");
            this.Property(t => t.AnswerB).HasColumnName("AnswerB");
            this.Property(t => t.AnswerC).HasColumnName("AnswerC");
            this.Property(t => t.AnswerD).HasColumnName("AnswerD");
            this.Property(t => t.Solution).HasColumnName("Solution");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.FormID).HasColumnName("FormID");
            this.Property(t => t.LevelId).HasColumnName("LevelId");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasOptional(t => t.tblCategory)
                .WithMany(t => t.tblQuestions)
                .HasForeignKey(d => d.CategoryID);
            this.HasOptional(t => t.tblForm)
                .WithMany(t => t.tblQuestions)
                .HasForeignKey(d => d.FormID);

        }
    }
}
