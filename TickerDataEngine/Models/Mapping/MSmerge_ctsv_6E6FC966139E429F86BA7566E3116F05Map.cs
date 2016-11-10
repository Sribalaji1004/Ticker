using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05Map : EntityTypeConfiguration<MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05>
    {
        public MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05Map()
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
            this.ToTable("MSmerge_ctsv_6E6FC966139E429F86BA7566E3116F05");
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
