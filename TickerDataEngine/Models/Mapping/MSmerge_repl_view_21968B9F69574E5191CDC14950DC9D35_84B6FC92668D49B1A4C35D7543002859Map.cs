using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.rowguid });

            // Properties
            this.Property(t => t.Abbreviation)
                .HasMaxLength(10);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.SponsorSync)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_84B6FC92668D49B1A4C35D7543002859");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.LockClient).HasColumnName("LockClient");
            this.Property(t => t.SponsorSync).HasColumnName("SponsorSync");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
