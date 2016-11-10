using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7BMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7B>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7BMap()
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
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_467DC94C223349C6A0417F1FD7AF9E7B");
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
