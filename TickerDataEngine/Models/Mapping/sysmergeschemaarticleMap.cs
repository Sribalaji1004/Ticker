using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergeschemaarticleMap : EntityTypeConfiguration<sysmergeschemaarticle>
    {
        public sysmergeschemaarticleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.name, t.objid, t.artid, t.pubid, t.destination_object, t.processing_order });

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.objid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.creation_script)
                .HasMaxLength(255);

            this.Property(t => t.schema_option)
                .IsFixedLength()
                .HasMaxLength(8);

            this.Property(t => t.destination_object)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.destination_owner)
                .HasMaxLength(128);

            this.Property(t => t.processing_order)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("sysmergeschemaarticles");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.objid).HasColumnName("objid");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.pre_creation_command).HasColumnName("pre_creation_command");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.creation_script).HasColumnName("creation_script");
            this.Property(t => t.schema_option).HasColumnName("schema_option");
            this.Property(t => t.destination_object).HasColumnName("destination_object");
            this.Property(t => t.destination_owner).HasColumnName("destination_owner");
            this.Property(t => t.processing_order).HasColumnName("processing_order");
        }
    }
}
