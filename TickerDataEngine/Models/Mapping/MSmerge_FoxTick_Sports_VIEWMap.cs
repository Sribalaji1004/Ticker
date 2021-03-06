using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_Sports_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_Sports_VIEW>
    {
        public MSmerge_FoxTick_Sports_VIEWMap()
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
            this.ToTable("MSmerge_FoxTick_Sports_VIEW");
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
