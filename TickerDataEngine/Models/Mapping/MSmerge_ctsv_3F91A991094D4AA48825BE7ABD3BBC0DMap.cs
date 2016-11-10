using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0DMap : EntityTypeConfiguration<MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0D>
    {
        public MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0DMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tablenick, t.rowguid, t.generation, t.lineage });

            // Properties
            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.generation)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lineage)
                .IsRequired()
                .HasMaxLength(311);

            this.Property(t => t.colv1)
                .HasMaxLength(2953);

            this.Property(t => t.logical_record_lineage)
                .HasMaxLength(311);

            // Table & Column Mappings
            this.ToTable("MSmerge_ctsv_3F91A991094D4AA48825BE7ABD3BBC0D");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.generation).HasColumnName("generation");
            this.Property(t => t.partchangegen).HasColumnName("partchangegen");
            this.Property(t => t.lineage).HasColumnName("lineage");
            this.Property(t => t.colv1).HasColumnName("colv1");
            this.Property(t => t.marker).HasColumnName("marker");
            this.Property(t => t.logical_record_parent_rowguid).HasColumnName("logical_record_parent_rowguid");
            this.Property(t => t.logical_record_lineage).HasColumnName("logical_record_lineage");
        }
    }
}
