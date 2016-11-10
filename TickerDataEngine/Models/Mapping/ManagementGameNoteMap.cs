using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class ManagementGameNoteMap : EntityTypeConfiguration<ManagementGameNote>
    {
        public ManagementGameNoteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GameID, t.PlayerID, t.rowguid });

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ManagementGameNotes");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
