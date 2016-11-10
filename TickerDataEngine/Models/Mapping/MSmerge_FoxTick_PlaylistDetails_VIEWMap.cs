using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_PlaylistDetails_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_PlaylistDetails_VIEW>
    {
        public MSmerge_FoxTick_PlaylistDetails_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.PlaylistID, t.EntryTypeID, t.EntryID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.PlaylistID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.EntryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_PlaylistDetails_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.PlaylistID).HasColumnName("PlaylistID");
            this.Property(t => t.EntryTypeID).HasColumnName("EntryTypeID");
            this.Property(t => t.EntryID).HasColumnName("EntryID");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
