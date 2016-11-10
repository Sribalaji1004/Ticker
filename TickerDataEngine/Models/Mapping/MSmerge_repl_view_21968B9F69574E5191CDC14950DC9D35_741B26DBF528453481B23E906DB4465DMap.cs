using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465DMap : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465D>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465DMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.GameID, t.AlertID, t.AlertTimeStamp, t.Alert, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.GameID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AlertID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Alert)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_741B26DBF528453481B23E906DB4465D");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.AlertID).HasColumnName("AlertID");
            this.Property(t => t.AlertTimeStamp).HasColumnName("AlertTimeStamp");
            this.Property(t => t.Alert).HasColumnName("Alert");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
