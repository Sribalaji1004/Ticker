using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ClientID, t.GameID, t.rowguid });

            // Properties
            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientIP)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_B34D66C5A09648778BE2364D1B50ED14");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
