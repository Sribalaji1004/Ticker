using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class NewsAlertMap : EntityTypeConfiguration<NewsAlert>
    {
        public NewsAlertMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            this.Property(t => t.Header)
                .HasMaxLength(50);

            this.Property(t => t.Alert)
                .IsRequired();

            this.Property(t => t.CreatedIP)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("NewsAlerts");
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
