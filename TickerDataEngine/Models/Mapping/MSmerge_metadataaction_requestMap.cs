using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_metadataaction_requestMap : EntityTypeConfiguration<MSmerge_metadataaction_request>
    {
        public MSmerge_metadataaction_requestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.tablenick, t.rowguid, t.action });

            // Properties
            this.Property(t => t.tablenick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_metadataaction_request");
            this.Property(t => t.tablenick).HasColumnName("tablenick");
            this.Property(t => t.rowguid).HasColumnName("rowguid");
            this.Property(t => t.action).HasColumnName("action");
            this.Property(t => t.generation).HasColumnName("generation");
            this.Property(t => t.changed).HasColumnName("changed");
        }
    }
}
