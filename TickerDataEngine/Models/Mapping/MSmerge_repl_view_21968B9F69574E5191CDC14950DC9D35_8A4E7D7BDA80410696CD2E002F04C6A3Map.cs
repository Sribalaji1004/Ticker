using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.ShortDisplay)
                .HasMaxLength(20);

            this.Property(t => t.LongDisplay)
                .HasMaxLength(50);

            this.Property(t => t.StatsIncName)
                .HasMaxLength(50);

            this.Property(t => t.SportType)
                .HasMaxLength(20);

            this.Property(t => t.DisplayField)
                .HasMaxLength(12);

            this.Property(t => t.GameFrequency)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_8A4E7D7BDA80410696CD2E002F04C6A3");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ShortDisplay).HasColumnName("ShortDisplay");
            this.Property(t => t.LongDisplay).HasColumnName("LongDisplay");
            this.Property(t => t.StatsIncName).HasColumnName("StatsIncName");
            this.Property(t => t.KeepResultsInDays).HasColumnName("KeepResultsInDays");
            this.Property(t => t.SportType).HasColumnName("SportType");
            this.Property(t => t.DisplayField).HasColumnName("DisplayField");
            this.Property(t => t.GameFrequency).HasColumnName("GameFrequency");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
