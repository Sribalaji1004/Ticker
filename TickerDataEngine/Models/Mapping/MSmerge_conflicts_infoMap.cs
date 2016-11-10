using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_conflicts_infoMap : EntityTypeConfiguration<MSmerge_conflicts_info>
    {
        public MSmerge_conflicts_infoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tablenick, t.rowguid, t.MSrepl_create_time });

            // Properties
            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.origin_datasource)
                .HasMaxLength(255);

            this.Property(t => t.reason_text)
                .HasMaxLength(720);

            // Table & Column Mappings
            this.ToTable("MSmerge_conflicts_info");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.origin_datasource).HasColumnName("origin_datasource");
            this.Property(t => t.conflict_type).HasColumnName("conflict_type");
            this.Property(t => t.reason_code).HasColumnName("reason_code");
            this.Property(t => t.reason_text).HasColumnName("reason_text");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.MSrepl_create_time).HasColumnName("MSrepl_create_time");
            this.Property(t => t.origin_datasource_id).HasColumnName("origin_datasource_id");
        }
    }
}
