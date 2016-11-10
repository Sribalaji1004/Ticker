using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_identity_rangeMap : EntityTypeConfiguration<MSmerge_identity_range>
    {
        public MSmerge_identity_rangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.subid, t.artid, t.is_pub_range });

            // Properties
            // Table & Column Mappings
            this.ToTable("MSmerge_identity_range");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.range_begin).HasColumnName("range_begin");
            this.Property(t => t.range_end).HasColumnName("range_end");
            this.Property(t => t.next_range_begin).HasColumnName("next_range_begin");
            this.Property(t => t.next_range_end).HasColumnName("next_range_end");
            this.Property(t => t.is_pub_range).HasColumnName("is_pub_range");
            this.Property(t => t.max_used).HasColumnName("max_used");
        }
    }
}
