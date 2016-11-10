using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ImporterMap : EntityTypeConfiguration<Importer>
    {
        public ImporterMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.RunDay)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.LastFileDate)
                .HasMaxLength(20);

            this.Property(t => t.LastMessage)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Importers");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RunDay).HasColumnName("RunDay");
            this.Property(t => t.RunHour).HasColumnName("RunHour");
            this.Property(t => t.RunMinute).HasColumnName("RunMinute");
            this.Property(t => t.Force).HasColumnName("Force");
            this.Property(t => t.LastRun).HasColumnName("LastRun");
            this.Property(t => t.LastFileDate).HasColumnName("LastFileDate");
            this.Property(t => t.LastSuccess).HasColumnName("LastSuccess");
            this.Property(t => t.LastMessage).HasColumnName("LastMessage");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
