using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.GameID, t.AltSortOrder, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AltSortOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_E6E5B14B1F21410AB211FF7E4C85B272");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AltSortOrder).HasColumnName("AltSortOrder");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
