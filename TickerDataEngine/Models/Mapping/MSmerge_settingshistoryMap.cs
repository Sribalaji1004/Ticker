using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_settingshistoryMap : EntityTypeConfiguration<MSmerge_settingshistory>
    {
        public MSmerge_settingshistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.pubid, t.eventtype });

            // Properties
            this.Property(t => t.propertyname)
                .HasMaxLength(128);

            this.Property(t => t.previousvalue)
                .HasMaxLength(128);

            this.Property(t => t.newvalue)
                .HasMaxLength(128);

            this.Property(t => t.eventtext)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("MSmerge_settingshistory");
            this.Property(t => t.eventtime).HasColumnName("eventtime");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.eventtype).HasColumnName("eventtype");
            this.Property(t => t.propertyname).HasColumnName("propertyname");
            this.Property(t => t.previousvalue).HasColumnName("previousvalue");
            this.Property(t => t.newvalue).HasColumnName("newvalue");
            this.Property(t => t.eventtext).HasColumnName("eventtext");
        }
    }
}
