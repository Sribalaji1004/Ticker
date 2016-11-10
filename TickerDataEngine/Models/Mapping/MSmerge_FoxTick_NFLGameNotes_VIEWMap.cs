using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_NFLGameNotes_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_NFLGameNotes_VIEW>
    {
        public MSmerge_FoxTick_NFLGameNotes_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Type, t.GameID, t.PlayerID, t.rowguid });

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_NFLGameNotes_VIEW");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
