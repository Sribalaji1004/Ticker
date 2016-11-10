using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ClientLogsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_ClientLogs>
    {
        public MSmerge_conflict_FoxTick_ClientLogsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Client, t.EntryType, t.Entry, t.EntryDate, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Client)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.EntryType)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Entry)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_ClientLogs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Client).HasColumnName("Client");
            this.Property(t => t.EntryType).HasColumnName("EntryType");
            this.Property(t => t.Entry).HasColumnName("Entry");
            this.Property(t => t.Temperature).HasColumnName("Temperature");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
