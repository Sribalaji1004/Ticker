using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47Map()
        {
            // Primary Key
            this.HasKey(t => new { t.AlertID, t.ClientIP, t.OnAirCount, t.rowguid });

            // Properties
            this.Property(t => t.AlertID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientIP)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.OnAirCount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_7973FE55EF8F480EBF7BC482250D7A47");
            this.Property(t => t.AlertID).HasColumnName("AlertID");
            this.Property(t => t.ClientIP).HasColumnName("ClientIP");
            this.Property(t => t.OnAirCount).HasColumnName("OnAirCount");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
