using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ImporterLogMap : EntityTypeConfiguration<ImporterLog>
    {
        public ImporterLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.EntryType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Entry)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ImporterLogs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ImporterID).HasColumnName("ImporterID");
            this.Property(t => t.EntryType).HasColumnName("EntryType");
            this.Property(t => t.Entry).HasColumnName("Entry");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
