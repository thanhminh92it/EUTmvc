using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EUTmvc.Models.Mapping;

namespace EUTmvc.Models
{
    public partial class EUTContext : DbContext
    {
        static EUTContext()
        {
            Database.SetInitializer<EUTContext>(null);
        }

        public EUTContext()
            : base("Name=EUTContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblAccount> tblAccounts { get; set; }
        public DbSet<tblArea> tblAreas { get; set; }
        public DbSet<tblAuthority> tblAuthorities { get; set; }
        public DbSet<tblCategory> tblCategories { get; set; }
        public DbSet<tblCountry> tblCountries { get; set; }
        public DbSet<tblDegree> tblDegrees { get; set; }
        public DbSet<tblDistrict> tblDistricts { get; set; }
        public DbSet<tblExamQuestion> tblExamQuestions { get; set; }
        public DbSet<tblExamStruct> tblExamStructs { get; set; }
        public DbSet<tblForm> tblForms { get; set; }
        public DbSet<tblGrade> tblGrades { get; set; }
        public DbSet<tblGroupAcount> tblGroupAcounts { get; set; }
        public DbSet<tblLevel> tblLevels { get; set; }
        public DbSet<tblNew> tblNews { get; set; }
        public DbSet<tblPerson> tblPersons { get; set; }
        public DbSet<tblQuestion> tblQuestions { get; set; }
        public DbSet<tblResult> tblResults { get; set; }
        public DbSet<tblSchool> tblSchools { get; set; }
        public DbSet<tblStatusAccount> tblStatusAccounts { get; set; }
        public DbSet<tblSubtest> tblSubtests { get; set; }
        public DbSet<tblSuggestion> tblSuggestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new tblAccountMap());
            modelBuilder.Configurations.Add(new tblAreaMap());
            modelBuilder.Configurations.Add(new tblAuthorityMap());
            modelBuilder.Configurations.Add(new tblCategoryMap());
            modelBuilder.Configurations.Add(new tblCountryMap());
            modelBuilder.Configurations.Add(new tblDegreeMap());
            modelBuilder.Configurations.Add(new tblDistrictMap());
            modelBuilder.Configurations.Add(new tblExamQuestionMap());
            modelBuilder.Configurations.Add(new tblExamStructMap());
            modelBuilder.Configurations.Add(new tblFormMap());
            modelBuilder.Configurations.Add(new tblGradeMap());
            modelBuilder.Configurations.Add(new tblGroupAcountMap());
            modelBuilder.Configurations.Add(new tblLevelMap());
            modelBuilder.Configurations.Add(new tblNewMap());
            modelBuilder.Configurations.Add(new tblPersonMap());
            modelBuilder.Configurations.Add(new tblQuestionMap());
            modelBuilder.Configurations.Add(new tblResultMap());
            modelBuilder.Configurations.Add(new tblSchoolMap());
            modelBuilder.Configurations.Add(new tblStatusAccountMap());
            modelBuilder.Configurations.Add(new tblSubtestMap());
            modelBuilder.Configurations.Add(new tblSuggestionMap());
        }
    }
}
