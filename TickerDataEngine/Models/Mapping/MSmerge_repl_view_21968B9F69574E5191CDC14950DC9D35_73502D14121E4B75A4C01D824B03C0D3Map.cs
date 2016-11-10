using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3Map : EntityTypeConfiguration<MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3>
    {
        public MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3Map()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Alert, t.Active, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            this.Property(t => t.Header)
                .HasMaxLength(50);

            this.Property(t => t.Alert)
                .IsRequired();

            this.Property(t => t.CreatedIP)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("MSmerge_repl_view_21968B9F69574E5191CDC14950DC9D35_73502D14121E4B75A4C01D824B03C0D3");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.Header).HasColumnName("Header");
            this.Property(t => t.Alert).HasColumnName("Alert");
            this.Property(t => t.AlertDate).HasColumnName("AlertDate");
            this.Property(t => t.PlayCount).HasColumnName("PlayCount");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedIP).HasColumnName("CreatedIP");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
