using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877Map()
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
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7036411C9AC14250956EEFB8CBB8E877");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.Note).HasColumnName("Note");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
