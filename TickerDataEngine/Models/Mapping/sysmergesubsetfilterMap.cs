using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class sysmergesubsetfilterMap : EntityTypeConfiguration<sysmergesubsetfilter>
    {
        public sysmergesubsetfilterMap()
        {
            // Primary Key
            this.HasKey(t => new { t.filtername, t.join_filterid, t.pubid, t.artid, t.art_nickname, t.join_articlename, t.join_nickname, t.join_unique_key, t.filter_type });

            // Properties
            this.Property(t => t.filtername)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.join_filterid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.art_nickname)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.join_articlename)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.join_nickname)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.join_unique_key)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.expand_proc)
                .HasMaxLength(128);

            this.Property(t => t.join_filterclause)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("sysmergesubsetfilters");
            this.Property(t => t.filtername).HasColumnName("filtername");
            this.Property(t => t.join_filterid).HasColumnName("join_filterid");
            this.Property(t => t.pubid).HasColumnName("pubid");
            this.Property(t => t.artid).HasColumnName("artid");
            this.Property(t => t.art_nickname).HasColumnName("art_nickname");
            this.Property(t => t.join_articlename).HasColumnName("join_articlename");
            this.Property(t => t.join_nickname).HasColumnName("join_nickname");
            this.Property(t => t.join_unique_key).HasColumnName("join_unique_key");
            this.Property(t => t.expand_proc).HasColumnName("expand_proc");
            this.Property(t => t.join_filterclause).HasColumnName("join_filterclause");
            this.Property(t => t.filter_type).HasColumnName("filter_type");
        }
    }
}
