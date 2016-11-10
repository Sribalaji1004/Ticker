using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_PlaylistsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_Playlists>
    {
        public MSmerge_conflict_FoxTick_PlaylistsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Name, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_Playlists");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.Locked).HasColumnName("Locked");
            this.Property(t => t.Staged).HasColumnName("Staged");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
