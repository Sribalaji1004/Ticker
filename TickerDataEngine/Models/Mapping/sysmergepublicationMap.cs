using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergepublicationMap : EntityTypeConfiguration<sysmergepublication>
    {
        public sysmergepublicationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.publisher, t.publisher_db, t.name, t.pubid, t.enabled_for_internet, t.dynamic_filters, t.snapshot_in_defaultfolder, t.compress_snapshot, t.ftp_port, t.backward_comp_level, t.max_concurrent_merge, t.max_concurrent_dynamic_snapshots, t.publication_number, t.replicate_ddl, t.allow_subscriber_initiated_snapshot, t.retention_period_unit, t.automatic_reinitialization_policy });

            // Properties
            this.Property(t => t.publisher)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.publisher_db)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.alt_snapshot_folder)
                .HasMaxLength(255);

            this.Property(t => t.pre_snapshot_script)
                .HasMaxLength(255);

            this.Property(t => t.post_snapshot_script)
                .HasMaxLength(255);

            this.Property(t => t.ftp_address)
                .HasMaxLength(128);

            this.Property(t => t.ftp_port)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ftp_subdirectory)
                .HasMaxLength(255);

            this.Property(t => t.ftp_login)
                .HasMaxLength(128);

            this.Property(t => t.ftp_password)
                .HasMaxLength(524);

            this.Property(t => t.validate_subscriber_info)
                .HasMaxLength(500);

            this.Property(t => t.ad_guidname)
                .HasMaxLength(128);

            this.Property(t => t.backward_comp_level)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.max_concurrent_merge)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.max_concurrent_dynamic_snapshots)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.dynamic_filters_function_list)
                .HasMaxLength(500);

            this.Property(t => t.partition_id_eval_proc)
                .HasMaxLength(128);

            this.Property(t => t.publication_number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.replicate_ddl)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.distributor)
                .HasMaxLength(128);

            this.Property(t => t.snapshot_jobid)
                .IsFixedLength()
                .HasMaxLength(16);

            this.Property(t => t.web_synchronization_url)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("sysmergepublications");
            this.Property(t => t.publisher).HasColumnName("publisher");
            this.Property(t => t.publisher_db).HasColumnName("publisher_db");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.retention).HasColumnName("retention");
            this.Property(t => t.publication_type).HasColumnName("publication_type");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.designmasterid).HasColumnName("designmasterid");
            this.Property(t => t.parentid).HasColumnName("parentid");
            this.Property(t => t.sync_mode).HasColumnName("sync_mode");
            this.Property(t => t.allow_push).HasColumnName("allow_push");
            this.Property(t => t.allow_pull).HasColumnName("allow_pull");
            this.Property(t => t.allow_anonymous).HasColumnName("allow_anonymous");
            this.Property(t => t.centralized_conflicts).HasColumnName("centralized_conflicts");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.snapshot_ready).HasColumnName("snapshot_ready");
            this.Property(t => t.enabled_for_internet).HasColumnName("enabled_for_internet");
            this.Property(t => t.dynamic_filters).HasColumnName("dynamic_filters");
            this.Property(t => t.snapshot_in_defaultfolder).HasColumnName("snapshot_in_defaultfolder");
            this.Property(t => t.alt_snapshot_folder).HasColumnName("alt_snapshot_folder");
            this.Property(t => t.pre_snapshot_script).HasColumnName("pre_snapshot_script");
            this.Property(t => t.post_snapshot_script).HasColumnName("post_snapshot_script");
            this.Property(t => t.compress_snapshot).HasColumnName("compress_snapshot");
            this.Property(t => t.ftp_address).HasColumnName("ftp_address");
            this.Property(t => t.ftp_port).HasColumnName("ftp_port");
            this.Property(t => t.ftp_subdirectory).HasColumnName("ftp_subdirectory");
            this.Property(t => t.ftp_login).HasColumnName("ftp_login");
            this.Property(t => t.ftp_password).HasColumnName("ftp_password");
            this.Property(t => t.conflict_retention).HasColumnName("conflict_retention");
            this.Property(t => t.keep_before_values).HasColumnName("keep_before_values");
            this.Property(t => t.allow_subscription_copy).HasColumnName("allow_subscription_copy");
            this.Property(t => t.allow_synctoalternate).HasColumnName("allow_synctoalternate");
            this.Property(t => t.validate_subscriber_info).HasColumnName("validate_subscriber_info");
            this.Property(t => t.ad_guidname).HasColumnName("ad_guidname");
            this.Property(t => t.backward_comp_level).HasColumnName("backward_comp_level");
            this.Property(t => t.max_concurrent_merge).HasColumnName("max_concurrent_merge");
            this.Property(t => t.max_concurrent_dynamic_snapshots).HasColumnName("max_concurrent_dynamic_snapshots");
            this.Property(t => t.use_partition_groups).HasColumnName("use_partition_groups");
            this.Property(t => t.dynamic_filters_function_list).HasColumnName("dynamic_filters_function_list");
            this.Property(t => t.partition_id_eval_proc).HasColumnName("partition_id_eval_proc");
            this.Property(t => t.publication_number).HasColumnName("publication_number");
            this.Property(t => t.replicate_ddl).HasColumnName("replicate_ddl");
            this.Property(t => t.allow_subscriber_initiated_snapshot).HasColumnName("allow_subscriber_initiated_snapshot");
            this.Property(t => t.distributor).HasColumnName("distributor");
            this.Property(t => t.snapshot_jobid).HasColumnName("snapshot_jobid");
            this.Property(t => t.allow_web_synchronization).HasColumnName("allow_web_synchronization");
            this.Property(t => t.web_synchronization_url).HasColumnName("web_synchronization_url");
            this.Property(t => t.allow_partition_realignment).HasColumnName("allow_partition_realignment");
            this.Property(t => t.retention_period_unit).HasColumnName("retention_period_unit");
            this.Property(t => t.decentralized_conflicts).HasColumnName("decentralized_conflicts");
            this.Property(t => t.generation_leveling_threshold).HasColumnName("generation_leveling_threshold");
            this.Property(t => t.automatic_reinitialization_policy).HasColumnName("automatic_reinitialization_policy");
        }
    }
}
