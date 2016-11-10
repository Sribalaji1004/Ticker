using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BFMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BF>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BFMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GroupID, t.Note, t.LastUpdated, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GroupID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Note)
                .IsRequired();

            this.Property(t => t.Header)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B93B4BF1EAA5447EB6A5F5B6827F41BF");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.NoteColor).HasColumnName("NoteColor");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Imported).HasColumnName("Imported");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
