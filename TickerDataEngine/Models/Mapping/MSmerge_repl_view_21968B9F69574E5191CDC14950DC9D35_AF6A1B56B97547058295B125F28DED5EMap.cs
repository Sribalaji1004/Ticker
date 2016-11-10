using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5EMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5E>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5EMap()
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
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_AF6A1B56B97547058295B125F28DED5E");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.principal_id).HasColumnName("principal_id");
            this.Property(t => t.diagram_id).HasColumnName("diagram_id");
            this.Property(t => t.version).HasColumnName("version");
            this.Property(t => t.definition).HasColumnName("definition");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
