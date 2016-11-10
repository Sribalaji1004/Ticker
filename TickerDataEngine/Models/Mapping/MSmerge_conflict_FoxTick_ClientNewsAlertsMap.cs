using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ClientNewsAlertsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_ClientNewsAlerts>
    {
        public MSmerge_conflict_FoxTick_ClientNewsAlertsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.AlertID, t.ClientIP, t.OnAirCount, t.rowguid });

            // Properties
            this.Property(t => t.AlertID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientIP)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.OnAirCount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_ClientNewsAlerts");
            this.Property(t => t.AlertID).HasColumnName("AlertID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.OnAirCount).HasColumnName("OnAirCount");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
