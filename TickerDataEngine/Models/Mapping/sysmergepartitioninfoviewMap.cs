using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergepartitioninfoviewMap : EntityTypeConfiguration<sysmergepartitioninfoview>
    {
        public sysmergepartitioninfoviewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.name, t.objid, t.sync_objid, t.artid, t.pubid, t.nickname, t.column_tracking, t.destination_object, t.excluded_col_count, t.vertical_partition, t.identity_support, t.allow_interactive_resolver, t.fast_multicol_updateproc, t.check_permissions, t.maxversion_at_cleanup, t.processing_order, t.upload_options, t.published_in_tran_pub, t.lightweight, t.compensate_for_errors, t.stream_blob_columns, t.preserve_rowguidcol });

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sync_objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.nickname)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.column_tracking)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.conflict_table)
                .HasMaxLength(128);

            this.Property(t => t.creation_script)
                .HasMaxLength(255);

            this.Property(t => t.conflict_script)
                .HasMaxLength(255);

            this.Property(t => t.article_resolver)
                .HasMaxLength(255);

            this.Property(t => t.ins_conflict_proc)
                .HasMaxLength(128);

            this.Property(t => t.insert_proc)
                .HasMaxLength(128);

            this.Property(t => t.update_proc)
                .HasMaxLength(128);

            this.Property(t => t.select_proc)
                .HasMaxLength(128);

            this.Property(t => t.metadata_select_proc)
                .HasMaxLength(128);

            this.Property(t => t.delete_proc)
                .HasMaxLength(128);

            this.Property(t => t.schema_option)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.destination_object)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.destination_owner)
                .HasMaxLength(128);

            this.Property(t => t.resolver_clsid)
                .HasMaxLength(50);

            this.Property(t => t.subset_filterclause)
                .HasMaxLength(1000);

            this.Property(t => t.missing_cols)
                .HasMaxLength(128);

            this.Property(t => t.excluded_cols)
                .HasMaxLength(128);

            this.Property(t => t.excluded_col_count)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.columns)
                .HasMaxLength(128);

            this.Property(t => t.deleted_cols)
                .HasMaxLength(128);

            this.Property(t => t.resolver_info)
                .HasMaxLength(517);

            this.Property(t => t.view_sel_proc)
                .HasMaxLength(290);

            this.Property(t => t.vertical_partition)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.identity_support)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.check_permissions)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.maxversion_at_cleanup)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.processing_order)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.procname_postfix)
                .IsFixedLength()
                .HasMaxLength(32);

            this.Property(t => t.membership_eval_proc_name)
                .HasMaxLength(128);

            this.Property(t => t.expand_proc)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("sysmergepartitioninfoview");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.objid).HasColumnName("objid");
            this.Property(t => t.sync_objid).HasColumnName("sync_objid");
            this.Property(t => t.view_type).HasColumnName("view_type");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.pre_creation_command).HasColumnName("pre_creation_command");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.nickname).HasColumnName("nickname");
            this.Property(t => t.column_tracking).HasColumnName("column_tracking");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.conflict_table).HasColumnName("conflict_table");
            this.Property(t => t.creation_script).HasColumnName("creation_script");
            this.Property(t => t.conflict_script).HasColumnName("conflict_script");
            this.Property(t => t.article_resolver).HasColumnName("article_resolver");
            this.Property(t => t.ins_conflict_proc).HasColumnName("ins_conflict_proc");
            this.Property(t => t.insert_proc).HasColumnName("insert_proc");
            this.Property(t => t.update_proc).HasColumnName("update_proc");
            this.Property(t => t.select_proc).HasColumnName("select_proc");
            this.Property(t => t.metadata_select_proc).HasColumnName("metadata_select_proc");
            this.Property(t => t.delete_proc).HasColumnName("delete_proc");
            this.Property(t => t.schema_option).HasColumnName("schema_option");
            this.Property(t => t.destination_object).HasColumnName("destination_object");
            this.Property(t => t.destination_owner).HasColumnName("destination_owner");
            this.Property(t => t.resolver_clsid).HasColumnName("resolver_clsid");
            this.Property(t => t.subset_filterclause).HasColumnName("subset_filterclause");
            this.Property(t => t.missing_col_count).HasColumnName("missing_col_count");
            this.Property(t => t.missing_cols).HasColumnName("missing_cols");
            this.Property(t => t.excluded_cols).HasColumnName("excluded_cols");
            this.Property(t => t.excluded_col_count).HasColumnName("excluded_col_count");
            this.Property(t => t.columns).HasColumnName("columns");
            this.Property(t => t.deleted_cols).HasColumnName("deleted_cols");
            this.Property(t => t.resolver_info).HasColumnName("resolver_info");
            this.Property(t => t.view_sel_proc).HasColumnName("view_sel_proc");
            this.Property(t => t.gen_cur).HasColumnName("gen_cur");
            this.Property(t => t.vertical_partition).HasColumnName("vertical_partition");
            this.Property(t => t.identity_support).HasColumnName("identity_support");
            this.Property(t => t.before_image_objid).HasColumnName("before_image_objid");
            this.Property(t => t.before_view_objid).HasColumnName("before_view_objid");
            this.Property(t => t.verify_resolver_signature).HasColumnName("verify_resolver_signature");
            this.Property(t => t.allow_interactive_resolver).HasColumnName("allow_interactive_resolver");
            this.Property(t => t.fast_multicol_updateproc).HasColumnName("fast_multicol_updateproc");
            this.Property(t => t.check_permissions).HasColumnName("check_permissions");
            this.Property(t => t.maxversion_at_cleanup).HasColumnName("maxversion_at_cleanup");
            this.Property(t => t.processing_order).HasColumnName("processing_order");
            this.Property(t => t.upload_options).HasColumnName("upload_options");
            this.Property(t => t.published_in_tran_pub).HasColumnName("published_in_tran_pub");
            this.Property(t => t.lightweight).HasColumnName("lightweight");
            this.Property(t => t.procname_postfix).HasColumnName("procname_postfix");
            this.Property(t => t.well_partitioned_lightweight).HasColumnName("well_partitioned_lightweight");
            this.Property(t => t.before_upd_view_objid).HasColumnName("before_upd_view_objid");
            this.Property(t => t.delete_tracking).HasColumnName("delete_tracking");
            this.Property(t => t.compensate_for_errors).HasColumnName("compensate_for_errors");
            this.Property(t => t.pub_range).HasColumnName("pub_range");
            this.Property(t => t.range).HasColumnName("range");
            this.Property(t => t.threshold).HasColumnName("threshold");
            this.Property(t => t.stream_blob_columns).HasColumnName("stream_blob_columns");
            this.Property(t => t.preserve_rowguidcol).HasColumnName("preserve_rowguidcol");
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
