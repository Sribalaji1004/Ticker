using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272Map : EntityTypeConfiguration<MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272>
    {
        public MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272Map()
        {
            // Primary Key
            this.HasKey(t => new { t.rowguid, t.tablenick, t.type, t.lineage, t.generation });

            // Properties
            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lineage)
                .IsRequired()
                .HasMaxLength(311);

            this.Property(t => t.generation)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.logical_record_lineage)
                .HasMaxLength(311);

            // Table & Column Mappings
            this.ToTable("MSmerge_tsvw_E6E5B14B1F21410AB211FF7E4C85B272");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.lineage).HasColumnName("lineage");
            this.Property(t => t.generation).HasColumnName("generation");
            this.Property(t => t.logical_record_parent_rowguid).HasColumnName("logical_record_parent_rowguid");
            this.Property(t => t.logical_record_lineage).HasColumnName("logical_record_lineage");
        }
    }
}
