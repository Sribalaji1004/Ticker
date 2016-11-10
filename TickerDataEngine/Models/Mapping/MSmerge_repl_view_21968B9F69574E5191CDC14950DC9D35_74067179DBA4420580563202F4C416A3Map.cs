using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.Description, t.rowguid });

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_74067179DBA4420580563202F4C416A3");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
