using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ClientAlerts_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ClientAlerts_VIEW>
    {
        public MSmerge_FoxTick_ClientAlerts_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ClientID, t.GameID, t.rowguid });

            // Properties
            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientIP)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ClientAlerts_VIEW");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
