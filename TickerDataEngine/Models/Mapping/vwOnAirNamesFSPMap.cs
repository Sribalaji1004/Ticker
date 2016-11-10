using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace FOXTickerDataEngine.Models.Mapping
{
    public class vwOnAirNamesFSPMap : EntityTypeConfiguration<vwOnAirNamesFSP>
    {
        public vwOnAirNamesFSPMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OnAirName)
                .HasMaxLength(50);

            this.Property(t => t.CreatedName)
                .HasMaxLength(50);

            this.Property(t => t.Expr1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vwOnAirNamesFSP");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.OnAirName).HasColumnName("OnAirName");
            this.Property(t => t.CreatedName).HasColumnName("CreatedName");
            this.Property(t => t.Expr1).HasColumnName("Expr1");
        }
    }
}
