using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSrepl_errorsMap : EntityTypeConfiguration<MSrepl_errors>
    {
        public MSrepl_errorsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.time });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.source_name)
                .HasMaxLength(100);

            this.Property(t => t.error_code)
                .HasMaxLength(128);

            this.Property(t => t.xact_seqno)
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("MSrepl_errors");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.time).HasColumnName("time");
            this.Property(t => t.error_type_id).HasColumnName("error_type_id");
            this.Property(t => t.source_type_id).HasColumnName("source_type_id");
            this.Property(t => t.source_name).HasColumnName("source_name");
            this.Property(t => t.error_code).HasColumnName("error_code");
            this.Property(t => t.error_text).HasColumnName("error_text");
            this.Property(t => t.xact_seqno).HasColumnName("xact_seqno");
            this.Property(t => t.command_id).HasColumnName("command_id");
            this.Property(t => t.session_id).HasColumnName("session_id");
        }
    }
}
