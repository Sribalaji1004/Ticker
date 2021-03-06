using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class GameNoteMap : EntityTypeConfiguration<GameNote>
    {
        public GameNoteMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Note)
                .IsRequired();

            this.Property(t => t.Header)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GameNotes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.NoteColor).HasColumnName("NoteColor");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Imported).HasColumnName("Imported");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.InGameStatID).HasColumnName("InGameStatID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
