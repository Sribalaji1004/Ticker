using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_ClientGamesMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_ClientGames>
    {
        public MSmerge_conflict_FoxTick_ClientGamesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.GameID, t.AltSortOrder, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltSortOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_ClientGames");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AltSortOrder).HasColumnName("AltSortOrder");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
