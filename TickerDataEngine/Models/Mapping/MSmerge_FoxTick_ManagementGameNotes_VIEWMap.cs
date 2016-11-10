using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ManagementGameNotes_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ManagementGameNotes_VIEW>
    {
        public MSmerge_FoxTick_ManagementGameNotes_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GameID, t.PlayerID, t.rowguid });

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ManagementGameNotes_VIEW");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
