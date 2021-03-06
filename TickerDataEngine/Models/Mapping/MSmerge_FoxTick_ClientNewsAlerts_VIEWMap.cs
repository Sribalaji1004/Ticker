using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ClientNewsAlerts_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ClientNewsAlerts_VIEW>
    {
        public MSmerge_FoxTick_ClientNewsAlerts_VIEWMap()
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
            this.ToTable("MSmerge_FoxTick_ClientNewsAlerts_VIEW");
            this.Property(t => t.AlertID).HasColumnName("AlertID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.OnAirCount).HasColumnName("OnAirCount");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
