using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_ClientGames_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_ClientGames_VIEW>
    {
        public MSmerge_FoxTick_ClientGames_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.GameID, t.AltSortOrder, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltSortOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_ClientGames_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AltSortOrder).HasColumnName("AltSortOrder");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
