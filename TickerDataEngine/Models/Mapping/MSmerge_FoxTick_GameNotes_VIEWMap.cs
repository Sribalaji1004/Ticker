using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_GameNotes_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_GameNotes_VIEW>
    {
        public MSmerge_FoxTick_GameNotes_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GameID, t.ClientID, t.Note, t.Imported, t.LastUpdated, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Note)
                .IsRequired();

            this.Property(t => t.Header)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_GameNotes_VIEW");
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
