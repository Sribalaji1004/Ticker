using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergepartitioninfoMap : EntityTypeConfiguration<sysmergepartitioninfo>
    {
        public sysmergepartitioninfoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.artid, t.pubid });

            // Properties
            this.Property(t => t.membership_eval_proc_name)
                .HasMaxLength(128);

            this.Property(t => t.expand_proc)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("sysmergepartitioninfo");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.partition_view_id).HasColumnName("partition_view_id");
            this.Property(t => t.repl_view_id).HasColumnName("repl_view_id");
            this.Property(t => t.partition_deleted_view_rule).HasColumnName("partition_deleted_view_rule");
            this.Property(t => t.partition_inserted_view_rule).HasColumnName("partition_inserted_view_rule");
            this.Property(t => t.membership_eval_proc_name).HasColumnName("membership_eval_proc_name");
            this.Property(t => t.column_list).HasColumnName("column_list");
            this.Property(t => t.column_list_blob).HasColumnName("column_list_blob");
            this.Property(t => t.expand_proc).HasColumnName("expand_proc");
            this.Property(t => t.logical_record_parent_nickname).HasColumnName("logical_record_parent_nickname");
            this.Property(t => t.logical_record_view).HasColumnName("logical_record_view");
            this.Property(t => t.logical_record_deleted_view_rule).HasColumnName("logical_record_deleted_view_rule");
            this.Property(t => t.logical_record_level_conflict_detection).HasColumnName("logical_record_level_conflict_detection");
            this.Property(t => t.logical_record_level_conflict_resolution).HasColumnName("logical_record_level_conflict_resolution");
            this.Property(t => t.partition_options).HasColumnName("partition_options");
        }
    }
}
