using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GameID, t.NetworkID, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NetworkID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_3B616ECE40DE406EA2F8C8EA0C730823");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.NetworkID).HasColumnName("NetworkID");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
