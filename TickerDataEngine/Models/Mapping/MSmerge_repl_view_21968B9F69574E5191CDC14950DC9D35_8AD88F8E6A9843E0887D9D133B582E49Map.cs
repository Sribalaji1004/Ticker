using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GameID, t.PlayerID, t.StatName, t.StatValue, t.LastUpdated, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.StatName)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.StatValue)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8AD88F8E6A9843E0887D9D133B582E49");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.StatName).HasColumnName("StatName");
            this.Property(t => t.StatValue).HasColumnName("StatValue");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
