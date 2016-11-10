using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergeschemachangeMap : EntityTypeConfiguration<sysmergeschemachange>
    {
        public sysmergeschemachangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.pubid, t.schemaversion, t.schemaguid, t.schematype, t.schematext, t.schemastatus, t.schemasubtype });

            // Properties
            this.Property(t => t.schemaversion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schematype)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.schematext)
                .IsRequired();

            this.Property(t => t.schemasubtype)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("sysmergeschemachange");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.schemaversion).HasColumnName("schemaversion");
            this.Property(t => t.schemaguid).HasColumnName("schemaguid");
            this.Property(t => t.schematype).HasColumnName("schematype");
            this.Property(t => t.schematext).HasColumnName("schematext");
            this.Property(t => t.schemastatus).HasColumnName("schemastatus");
            this.Property(t => t.schemasubtype).HasColumnName("schemasubtype");
        }
    }
}
