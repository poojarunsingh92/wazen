using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace WazenIdentity.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Viewer",
                    NormalizedName = "VIEWER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                 new IdentityRole
                 {
                     Name = "SYSTEM_ADMIN",
                     NormalizedName = "SYSTEM_ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "IC_ADMIN",
                     NormalizedName = "IC_ADMIN"
                 },
                 new IdentityRole
                 {
                     Name = "CUSTOMER",
                     NormalizedName = "CUSTOMER"
                 }
            );
        }
    }
}
