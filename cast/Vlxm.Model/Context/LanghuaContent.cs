using System.Data.Entity;
using Vlxm.Model.Models;

namespace Vlxm.Data
{

    public partial class LanghuaContext : DbContext
    {
        public LanghuaContext()
            : base("name=LanghuaContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
			modelBuilder.Properties<System.DateTime>().Configure(x => x.HasColumnType("datetime2"));
        }

        public DbSet<User> Users { get; set; }

    }
}
