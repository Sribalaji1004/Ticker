using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_EntryTypes_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_EntryTypes_VIEW>
    {
        public MSmerge_FoxTick_EntryTypes_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.rowguid });

            // Properties
            this.Property(t => t.Abbreviation)
                .HasMaxLength(20);

            this.Property(t => t.Description)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_EntryTypes_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
