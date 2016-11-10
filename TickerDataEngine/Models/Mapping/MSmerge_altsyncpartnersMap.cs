using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_altsyncpartnersMap : EntityTypeConfiguration<MSmerge_altsyncpartners>
    {
        public MSmerge_altsyncpartnersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.subid, t.alternate_subid });

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MSmerge_altsyncpartners");
            this.Property(t => t.subid).HasColumnName("subid");
            this.Property(t => t.alternate_subid).HasColumnName("alternate_subid");
            this.Property(t => t.description).HasColumnName("description");
        }
    }
}
