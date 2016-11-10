using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
        public NoteMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Note1)
                .IsRequired();

            this.Property(t => t.Header)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Notes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GroupID).HasColumnName("GroupID");
            this.Property(t => t.Note1).HasColumnName("Note");
            this.Property(t => t.NoteColor).HasColumnName("NoteColor");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Imported).HasColumnName("Imported");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.Notes)
                .HasForeignKey(d => d.GroupID);

        }
    }
}
