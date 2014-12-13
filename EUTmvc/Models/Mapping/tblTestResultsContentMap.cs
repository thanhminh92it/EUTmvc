using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblTestResultsContentMap : EntityTypeConfiguration<tblTestResultsContent>
    {
        public tblTestResultsContentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Answers)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblTestResultsContent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TestResultId).HasColumnName("TestResultId");
            this.Property(t => t.ExamStructId).HasColumnName("ExamStructId");
            this.Property(t => t.Answers).HasColumnName("Answers");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.ModifiedCount).HasColumnName("ModifiedCount");

            // Relationships
            this.HasRequired(t => t.tblExamStruct)
                .WithMany(t => t.tblTestResultsContents)
                .HasForeignKey(d => d.ExamStructId);
            this.HasRequired(t => t.tblTestResult)
                .WithMany(t => t.tblTestResultsContents)
                .HasForeignKey(d => d.TestResultId);

        }
    }
}
