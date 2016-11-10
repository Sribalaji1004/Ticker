using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflict_FoxTick_sysdiagramsMap : EntityTypeConfiguration<MSmerge_conflict_FoxTick_sysdiagrams>
    {
        public MSmerge_conflict_FoxTick_sysdiagramsMap()
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
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflict_FoxTick_sysdiagrams");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.principal_id).HasColumnName("principal_id");
            this.Property(t => t.diagram_id).HasColumnName("diagram_id");
            this.Property(t => t.version).HasColumnName("version");
            this.Property(t => t.definition).HasColumnName("definition");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
