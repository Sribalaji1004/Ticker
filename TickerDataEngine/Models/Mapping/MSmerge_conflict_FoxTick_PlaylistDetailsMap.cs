using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_PlaylistDetailsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_PlaylistDetails>
    {
        public MSmerge_conflict_FoxTick_PlaylistDetailsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.PlaylistID, t.EntryTypeID, t.EntryID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlaylistID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EntryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_PlaylistDetails");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PlaylistID).HasColumnName("PlaylistID");
            this.Property(t => t.EntryTypeID).HasColumnName("EntryTypeID");
            this.Property(t => t.EntryID).HasColumnName("EntryID");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
