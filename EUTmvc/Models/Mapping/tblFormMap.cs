using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EUTmvc.Models.Mapping
{
    public class tblFormMap : EntityTypeConfiguration<tblForm>
    {
        public tblFormMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("tblForm");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Request).HasColumnName("Request");
            this.Property(t => t.QuestionNumber).HasColumnName("QuestionNumber");
        }
    }
}
