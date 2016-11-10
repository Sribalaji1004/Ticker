using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9BMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9B>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9BMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GameID, t.PlayerID, t.rowguid });

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PlayerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_6C8A90F5829646DB940996D053BBCE9B");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.PlayerID).HasColumnName("PlayerID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
