using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83ABMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83AB>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83ABMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GameID, t.rowguid });

            // Properties
            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Clock)
                .IsFixedLength()
                .HasMaxLength(18);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_F9D70570176F45A79E27B75A427B83AB");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.GameStatusID).HasColumnName("GameStatusID");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Clock).HasColumnName("Clock");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.HomeScore).HasColumnName("HomeScore");
            this.Property(t => t.VisitorsScore).HasColumnName("VisitorsScore");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
