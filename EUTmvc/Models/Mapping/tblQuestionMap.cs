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
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblQuestion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Contents).HasColumnName("Contents");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.LevelId).HasColumnName("LevelId");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.AnswerA).HasColumnName("AnswerA");
            this.Property(t => t.AnswerB).HasColumnName("AnswerB");
            this.Property(t => t.AnswerC).HasColumnName("AnswerC");
            this.Property(t => t.AnswerD).HasColumnName("AnswerD");
            this.Property(t => t.SuggestionId).HasColumnName("SuggestionId");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.tblCategory)
                .WithMany(t => t.tblQuestions)
                .HasForeignKey(d => d.CategoryId);
            this.HasOptional(t => t.tblLevel)
                .WithMany(t => t.tblQuestions)
                .HasForeignKey(d => d.LevelId);
            this.HasOptional(t => t.tblSuggestion)
                .WithMany(t => t.tblQuestions)
                .HasForeignKey(d => d.SuggestionId);

        }
    }
}
