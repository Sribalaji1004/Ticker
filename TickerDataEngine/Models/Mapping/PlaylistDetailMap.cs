using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class PlaylistDetailMap : EntityTypeConfiguration<PlaylistDetail>
    {
        public PlaylistDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PlaylistDetails");
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
