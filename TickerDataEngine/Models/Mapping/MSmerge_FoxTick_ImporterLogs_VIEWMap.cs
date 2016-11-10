using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ImporterLogs_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ImporterLogs_VIEW>
    {
        public MSmerge_FoxTick_ImporterLogs_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ImporterID, t.EntryType, t.Entry, t.EntryDate, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ImporterID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EntryType)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Entry)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ImporterLogs_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ImporterID).HasColumnName("ImporterID");
            this.Property(t => t.EntryType).HasColumnName("EntryType");
            this.Property(t => t.Entry).HasColumnName("Entry");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
