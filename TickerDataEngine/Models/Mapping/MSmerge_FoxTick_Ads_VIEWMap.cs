using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_FoxTick_Ads_VIEWMap : EntityTypeConfiguration<MSmerge_FoxTick_Ads_VIEW>
    {
        public MSmerge_FoxTick_Ads_VIEWMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID, t.ClientID, t.Name, t.FileName, t.LastUpdated, t.rowguid });

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ClientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            this.Property(t => t.FileName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MSmerge_FoxTick_Ads_VIEW");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.LastUpdated).HasColumnName("LastUpdated");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
        }
    }
}
