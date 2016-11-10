using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_sysdiagrams_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_sysdiagrams_VIEW>
    {
        public MSmerge_FoxTick_sysdiagrams_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.name, t.principal_id, t.diagram_id, t.rowguid });

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.principal_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.diagram_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_sysdiagrams_VIEW");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.principal_id).HasColumnName("principal_id");
            this.Property(t => t.diagram_id).HasColumnName("diagram_id");
            this.Property(t => t.version).HasColumnName("version");
            this.Property(t => t.definition).HasColumnName("definition");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
