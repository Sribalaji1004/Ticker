using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_agent_parametersMap : EntityTypeConfiguration<MSmerge_agent_parameters>
    {
        public MSmerge_agent_parametersMap()
        {
            // Primary Key
            this.HasKey(t => new { t.profile_name, t.parameter_name, t.value });

            // Properties
            this.Property(t => t.profile_name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.parameter_name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.value)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("MSmerge_agent_parameters");
            this.Property(t => t.profile_name).HasColumnName("profile_name");
            this.Property(t => t.parameter_name).HasColumnName("parameter_name");
            this.Property(t => t.value).HasColumnName("value");
        }
    }
}
