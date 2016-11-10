using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950Map : EntityTypeConfiguration<MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950>
    {
        public MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950Map()
        {
            // Primary Key
            this.HasKey(t => new { t.guidsrc, t.generation, t.nicknames, t.coldate, t.genstatus, t.changecount, t.subscriber_number });

            // Properties
            this.Property(t => t.generation)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.nicknames)
                .IsRequired()
                .HasMaxLength(1001);

            this.Property(t => t.changecount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.subscriber_number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSmerge_genvw_3A27831AF4504C79AF0092DC4EAA0950");
            this.Property(t => t.guidsrc).HasColumnName("guidsrc");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.generation).HasColumnName("generation");
            this.Property(t => t.art_nick).HasColumnName("art_nick");
            this.Property(t => t.nicknames).HasColumnName("nicknames");
            this.Property(t => t.coldate).HasColumnName("coldate");
            this.Property(t => t.genstatus).HasColumnName("genstatus");
            this.Property(t => t.changecount).HasColumnName("changecount");
            this.Property(t => t.subscriber_number).HasColumnName("subscriber_number");
        }
    }
}
