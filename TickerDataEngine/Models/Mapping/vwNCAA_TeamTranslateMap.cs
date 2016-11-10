using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class vwNCAA_TeamTranslateMap : EntityTypeConfiguration<vwNCAA_TeamTranslate>
    {
        public vwNCAA_TeamTranslateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SRC_ID, t.SRC_ABB, t.SRC_NICKNAME, t.CPY_ID, t.CPY_ABB, t.CPY_NICKNAME });

            // Properties
            this.Property(t => t.SRC_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SRC_ABB)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.SRC_NICKNAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SRC_PRIMARYCOLOR)
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.CPY_ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CPY_ABB)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CPY_NICKNAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CPY_PRIMARYCOLOR)
                .IsFixedLength()
                .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("vwNCAA_TeamTranslate");
            this.Property(t => t.SRC_ID).HasColumnName("SRC_ID");
            this.Property(t => t.SRC_ABB).HasColumnName("SRC_ABB");
            this.Property(t => t.SRC_NICKNAME).HasColumnName("SRC_NICKNAME");
            this.Property(t => t.SRC_PRIMARYCOLOR).HasColumnName("SRC_PRIMARYCOLOR");
            this.Property(t => t.CPY_ID).HasColumnName("CPY_ID");
            this.Property(t => t.CPY_ABB).HasColumnName("CPY_ABB");
            this.Property(t => t.CPY_NICKNAME).HasColumnName("CPY_NICKNAME");
            this.Property(t => t.CPY_PRIMARYCOLOR).HasColumnName("CPY_PRIMARYCOLOR");
        }
    }
}
