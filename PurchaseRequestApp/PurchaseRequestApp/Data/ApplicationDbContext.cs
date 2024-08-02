using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurchaseRequestApp.Models;
using Microsoft.AspNetCore.Identity;

namespace PurchaseRequestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
    }
}
