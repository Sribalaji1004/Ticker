using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergesubscriptionMap : EntityTypeConfiguration<sysmergesubscription>
    {
        public sysmergesubscriptionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.db_name, t.datasource_type, t.subid, t.replnickname, t.replicastate, t.status, t.subscriber_type, t.subscription_type, t.sync_type, t.metadatacleanuptime, t.cleanedup_unsent_changes, t.replica_version, t.supportability_mode, t.subscriber_number });

            // Properties
            this.Property(t => t.subscriber_server)
                .HasMaxLength(128);

            this.Property(t => t.db_name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.datasource_type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.replnickname)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(6);

            this.Property(t => t.subscriber_type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.subscription_type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.last_sync_summary)
                .HasMaxLength(128);

            this.Property(t => t.replica_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.supportability_mode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.application_name)
                .HasMaxLength(128);

            this.Property(t => t.subscriber_number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("sysmergesubscriptions");
            this.Property(t => t.subscriber_server).HasColumnName("subscriber_server");
            this.Property(t => t.db_name).HasColumnName("db_name");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.datasource_type).HasColumnName("datasource_type");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.replnickname).HasColumnName("replnickname");
            this.Property(t => t.replicastate).HasColumnName("replicastate");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.subscriber_type).HasColumnName("subscriber_type");
            this.Property(t => t.subscription_type).HasColumnName("subscription_type");
            this.Property(t => t.sync_type).HasColumnName("sync_type");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.priority).HasColumnName("priority");
            this.Property(t => t.recgen).HasColumnName("recgen");
            this.Property(t => t.recguid).HasColumnName("recguid");
            this.Property(t => t.sentgen).HasColumnName("sentgen");
            this.Property(t => t.sentguid).HasColumnName("sentguid");
            this.Property(t => t.schemaversion).HasColumnName("schemaversion");
            this.Property(t => t.schemaguid).HasColumnName("schemaguid");
            this.Property(t => t.last_validated).HasColumnName("last_validated");
            this.Property(t => t.attempted_validate).HasColumnName("attempted_validate");
            this.Property(t => t.last_sync_date).HasColumnName("last_sync_date");
            this.Property(t => t.last_sync_status).HasColumnName("last_sync_status");
            this.Property(t => t.last_sync_summary).HasColumnName("last_sync_summary");
            this.Property(t => t.metadatacleanuptime).HasColumnName("metadatacleanuptime");
            this.Property(t => t.partition_id).HasColumnName("partition_id");
            this.Property(t => t.cleanedup_unsent_changes).HasColumnName("cleanedup_unsent_changes");
            this.Property(t => t.replica_version).HasColumnName("replica_version");
            this.Property(t => t.supportability_mode).HasColumnName("supportability_mode");
            this.Property(t => t.application_name).HasColumnName("application_name");
            this.Property(t => t.subscriber_number).HasColumnName("subscriber_number");
            this.Property(t => t.last_makegeneration_datetime).HasColumnName("last_makegeneration_datetime");
        }
    }
}
