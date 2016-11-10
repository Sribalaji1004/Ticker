using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ManagementGamesMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_ManagementGames>
    {
        public MSmerge_conflict_FoxTick_ManagementGamesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GameID, t.rowguid });

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Clock)
                .IsFixedLength()
                .HasMaxLength(18);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_ManagementGames");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.GameStatusID).HasColumnName("GameStatusID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Clock).HasColumnName("Clock");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.HomeScore).HasColumnName("HomeScore");
            this.Property(t => t.VisitorsScore).HasColumnName("VisitorsScore");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
