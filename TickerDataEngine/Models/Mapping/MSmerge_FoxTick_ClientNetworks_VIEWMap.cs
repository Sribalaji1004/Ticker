using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ClientNetworks_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ClientNetworks_VIEW>
    {
        public MSmerge_FoxTick_ClientNetworks_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GameID, t.NetworkID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NetworkID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ClientNetworks_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.NetworkID).HasColumnName("NetworkID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
